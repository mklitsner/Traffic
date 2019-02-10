using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour {
	public float maxIntensity=1;
	public float minIntensity=0;
	float lightIntensity;
	Color lightColor;
	public Color happyColor;
	public Color sadColor;
	public Color spookyColor;
	public GameObject DashBoard;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {



		float mood = DashBoard.GetComponent<DashboardOutput> ().channelTune;

		lightIntensity = scale (5, 1, minIntensity, maxIntensity, mood);


		if (mood <= 3.5){
			lightColor = Color.Lerp (happyColor, sadColor, scale (0, 1, 1, 3.5f, mood));
	}else {
			lightColor = Color.Lerp (sadColor, spookyColor, scale (0, 1, 3.5f, 5, mood));
	}

		GetComponent<Light> ().intensity=lightIntensity;

		GetComponent<Light> ().color = lightColor;

		
	}

	float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){

		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return(NewValue);
	}
}

