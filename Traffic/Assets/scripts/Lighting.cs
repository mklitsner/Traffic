using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour {
	public float maxIntensity=1;
	public float minIntensity=0;
	float lightIntensity;
	Color lightColor;

    float colorTime;
	public Color happyColor;
	public Color sadColor;
	public Color spookyColor;
	public GameObject DashBoard;

	// Use this for initialization
	void Start () {
        colorTime = 1;
	}
	
	// Update is called once per frame
	void Update () {

        Color lightColorTarget;

		float mood = DashBoard.GetComponent<DashboardOutput> ().channelTune;

		 
        float lightIntensityTarget=scale(5, 1, minIntensity, maxIntensity, mood);

        if (mood <= 3.5){
            lightColorTarget = Color.Lerp (happyColor, sadColor, scale (0, 1, 1, 3.5f, mood));
	}else {
            lightColorTarget = Color.Lerp (sadColor, spookyColor, scale (0, 1, 3.5f, 5, mood));
	}
        //smooth transitions
        if (lightColorTarget != lightColor&&colorTime<1)
        {
            colorTime += Time.deltaTime*0.2f;
            lightColor= Color.Lerp(lightColor, lightColorTarget,colorTime);
            lightIntensity = Mathf.Lerp(lightIntensity, lightIntensityTarget, colorTime);
        }
        else
        {
            colorTime = 0;
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

