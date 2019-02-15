using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficScript : MonoBehaviour {

	public float speed;
	public float speedmultiplier;
	public float threshold;
	public GameObject Arduino;
	bool hit;
    float drift;

	// Use this for initialization
	void Start () {
        Arduino = GameObject.Find("DigitalDashboardController");
        drift = Random.Range(-0.1f, 0.1f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		


		speed = scale(-1,1,0.03f,0.5f,Arduino.GetComponent<DashboardOutput> ().intensity)*speedmultiplier;
		
		transform.Translate(0,0,-speed);
        transform.Translate(drift* Arduino.GetComponent<DashboardOutput>().intensityBuild, 0, 0);

        if (transform.position.z<threshold){
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

