using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
	public GameObject Arduino;
	float timeLeft = 1.0f;
	public int ignition;


	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		ignition = Arduino.GetComponent<DashboardInterfaceReader> ().ignitionState;
		if (ignition ==1) {
			timeLeft = timeLeft - Time.deltaTime;
			if (timeLeft < 0) {
				SceneManager.LoadScene ("Car Test2");
			}
		}
	}
}
