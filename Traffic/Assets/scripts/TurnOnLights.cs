using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour {


	// Use this for initialization

	// Update is called once per frame
	void Update () {
		GameObject Dashboard = GameObject.Find ("DigitalDashboardController");
		if(Dashboard.GetComponent<DashboardOutput>().channelTune>4){
			
			transform.GetChild (0).gameObject.SetActive (true);
			transform.GetChild (1).gameObject.SetActive (true);

			//print ("lightsOn");
		}else{
			//print ("lightsOFF");
			transform.GetChild (0).gameObject.SetActive (false);
			transform.GetChild (1).gameObject.SetActive (false);
		
	}
}
}
