using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour {


	float timeLeft = 30.0f;
	Text textCredit; 
	public bool showTitle;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		

		textCredit = GetComponent<Text> ();
		timeLeft -= Time.deltaTime; 

		textCredit.text = "Created by Miller Klitsner";

		if (timeLeft < 25.0f) {
//			StartCoroutine (FadeTo (0.0f, 5.0f));
			textCredit.text = "Music Arranged by Cole Brossus";

		}
		if (timeLeft < 20.0f) {
//			StartCoroutine (FadeTo (0.0f, 5.0f));
			textCredit.text = "Special Thanks to:\n Hillary Cleary,\n Dan Klisner,\n Will Kepler\n & Ben Briggance";
		}
		if (timeLeft < 10) {
			textCredit.text = " ";


		}
		if (timeLeft < 0) {
			textCredit.text = "insert your car keys into the ignition and turn clockwise to begin";

		}
	}



	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = transform.GetComponent<Text>().color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			gameObject.GetComponent<Text> ().color = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));

			yield return null;
		}
	}
}


//special thanks to Dan Klisner & Will Kepler & Ben Briggance
//Cole Brossus 
//Hillary Cleary 
//

