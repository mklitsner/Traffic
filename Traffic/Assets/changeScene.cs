﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
	public GameObject Arduino;
	float timeLeft = 1.0f;
	public float ignition;


	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		ignition = Arduino.GetComponent<DashboardInterfaceReader> ().ignition;
		if (ignition > 1000) {
			timeLeft = timeLeft - Time.deltaTime;
			if (timeLeft < 0) {
				SceneManager.LoadScene ("Car Test1");
			}
		}
	}
}