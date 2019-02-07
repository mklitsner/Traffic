using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour {

	public float speed;
	public float speedmultiplier;
	public float threshold;
	public GameObject Arduino;
	bool hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Arduino = GameObject.Find ("DigitalDashboardController");

		speed = scale(-1,1,0.03f,0.5f,Arduino.GetComponent<DashboardOutput> ().intensity)*speedmultiplier;
		
		transform.Translate(0,0,-speed);

		if(transform.position.z<threshold){
			Destroy(gameObject);
		}






}

	float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){

		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return(NewValue);
	}


}

