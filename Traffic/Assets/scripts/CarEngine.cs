using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarEngine : MonoBehaviour {

	public GameObject Arduino;
	float intensity;
	float pitch;

	public Transform path;
	public float maxSteerAngle = 50f;
	public float maxTorque= 30f;
	public float velocity;
	public float maxAcceleration = 10f;
	public float maxDeacceleration = -20f;
	public float acceleration=10f;
	public float turnPercision;
	float channel;
	public int reverse=1;

	public WheelCollider[] wheelcollider = new WheelCollider[4];
	public Transform[] wheelmesh = new Transform[4];


	private int currentNode =0;
	private List<Transform> nodes;

	// Use this for initialization
	void Start () {
		turnPercision=15;

		Transform[] pathTransforms = path.GetComponentsInChildren<Transform> ();
		nodes = new List<Transform> ();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms[i] != path.transform){
				nodes.Add(pathTransforms[i]);
			}
		}

	}

	void FixedUpdate (){
		intensity=Arduino.GetComponent<DashboardOutput> ().intensity;
		channel=Arduino.GetComponent<DashboardOutput> ().channelTune;
		pitch=Arduino.GetComponent<DashboardOutput> ().pitch;

		velocity = GetComponent<Rigidbody> ().velocity.magnitude;
		Time.timeScale = scale(-1,1,0.1f,4,intensity);
		ApplySteer();
		ApplyAcceleration ();
		UpdateMeshPositions ();

	}

	void ApplySteer(){
		Vector3 relativeVector = transform.InverseTransformPoint (nodes [currentNode].position);
//		relativeVector = relativeVector / relativeVector.magnitude;
		float newsteer = (relativeVector.x/ relativeVector.magnitude)*-maxSteerAngle;
		wheelcollider[0].steerAngle = newsteer;
		wheelcollider[3].steerAngle = newsteer;




		// go to next node if the current node is reached
		float nodeDistance = Vector3.Distance (transform.position, nodes [currentNode].position);

		//print (newsteer);


		if (velocity > 2) {
			acceleration = (maxAcceleration * ((maxSteerAngle - Mathf.Abs(newsteer)) / maxSteerAngle));
		} else{
			acceleration = maxAcceleration;
		}

		//pounce
		if (channel < 2) {
			if (nodeDistance < 15 && nodeDistance > 14) {
				GetComponent<Rigidbody> ().AddForce (transform.up * 400, ForceMode.Impulse);
			}
		}

//		print (nodeDistance);

		if (nodeDistance > 5) {
			reverse = 1;
		}


		if (nodeDistance < turnPercision) {
			currentNode++;

			if (currentNode>=nodes.Count) {
				currentNode = 0;
			}
				
			
	}
	}

	void ApplyAcceleration (){
		if (velocity < 2) {
			GetComponent<Rigidbody> ().AddForce (-transform.up*1000);
		}
	
		for (int i = 1; i < 3; i++) {
			wheelcollider [i].motorTorque = -acceleration * maxTorque * reverse*scale(-1,1,0.5f,1.5f,intensity);
		}
	}



	void UpdateMeshPositions(){
		for (int i = 0; i < 4; i++) {
			Quaternion quat;
			Vector3 pos;
			wheelcollider [i].GetWorldPose (out pos, out quat);

			wheelmesh [i].position = pos;
			wheelmesh [i].rotation = quat;
		}

	}

	void OnCollisionStay(Collision collision){
		if (reverse > 0) {
			reverse = -10;
			//print (gameObject.name + "had a collision");
		} else {
			reverse = 1; 
		}
	}
		

	float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){

		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return(NewValue);
	}

	

}
