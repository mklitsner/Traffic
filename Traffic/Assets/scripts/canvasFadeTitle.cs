using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasFadeTitle : MonoBehaviour {
	public GameObject Arduino;
	float timeLeft = 4.0f;
	public float ignition;


	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		ignition=Arduino.GetComponent<DashboardInterfaceReader> ().ignition;

	

		
		//gameObject.GetComponent<Image> ().color= new Color(0,1,0,0.8f);

		//if ignition turned on/off
		if(Input.GetKeyUp(KeyCode.T)||ignition>1000)
		{
			StartCoroutine(FadeTo(1.0f, 1.0f));
		}
		if(Input.GetKeyUp(KeyCode.F)||ignition<900)
		{
			StartCoroutine(FadeTo(0.0f, 1.0f));
		}

	}

	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = transform.GetComponent<Image>().color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			gameObject.GetComponent<Image> ().color = new Color(0, 0, 0, Mathf.Lerp(alpha,aValue,t));

			yield return null;
		}
	}



}




