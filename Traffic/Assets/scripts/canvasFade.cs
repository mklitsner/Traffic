using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasFade : MonoBehaviour {
	public GameObject Arduino;
	float timeLeft = 20.0f;
	public float ignition;


	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		ignition=Arduino.GetComponent<DashboardInterfaceReader> ().ignition;

		//gameObject.GetComponent<Image> ().color= new Color(0,1,0,0.8f);

		//if ignition turned on/off
		if (ignition < 900) {
			SceneManager.LoadScene ("Title");
		}


	}



}




