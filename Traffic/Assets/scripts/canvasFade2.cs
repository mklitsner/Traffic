using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasFade2 : MonoBehaviour {
	public GameObject Arduino;
	float timeLeft = 20.0f;
	public float ignition;
	public Color solidColor;
	public Color alpha;


	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		ignition=Arduino.GetComponent<DashboardInterfaceReader> ().ignition;
		


	}



}




