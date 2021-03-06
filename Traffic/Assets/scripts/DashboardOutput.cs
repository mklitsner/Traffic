﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DashboardOutput : MonoBehaviour {

	public AudioMixer masterMixer;
	public AudioMixer upliftingMixer;
	public AudioMixer nuetralMixer;
	public AudioMixer sadMixer;
	public AudioMixer spookyMixer;
   public AudioMixer lightMixer;
    public AudioMixer darkMixer;

    [Range(-80, 0f)] public float masterVol = -12;
    [Range(1f,3.0f)]public float musicSpeed=1.0f;
	[Range(0.5f,2.0f)]public float pitch=1.0f;
	[Range(-1,1)]public float intensity;
    [Range(0, 1)] public float intensityBuild;

    [Range(1,5)]public float channelTune;
	public bool hazardlights=false;

	public bool testingOnArduino;







    // Update is called once per frame
    void Update () {

        if (intensity > 0.8f)
        {
            if (intensityBuild < 1)
            {
                intensityBuild += 0.001f;

            }


        }
        else
        {
            if (intensityBuild > 0)
            {
                intensityBuild -= 0.1f;

            }

        }

        CorrectPitchOnSpeedChange ();

		if (testingOnArduino) {
			MapGasandBrakeToIntensity();
			MapVolumeKnobToPitch ();
			MapTunerKnobToMood ();
			if (GameObject.Find ("DashboardController").GetComponent<DashboardInterfaceReader> ().hazardButtonState == 0) {
				hazardlights = true;
			} else {
				hazardlights = false;
			}

		}

		intensity = Mathf.Round (intensity*1000)/1000;

		MapIntensityToAudio (intensity,nuetralMixer,"nuetralLo","nuetralMed","nuetralHi");
		MapIntensityToAudio (intensity,sadMixer,"sadLo","sadMed","sadHi");
        MapIntensityToAudio(intensity, upliftingMixer, "upliftingLo", "upliftingMed", "upliftingHi");
        MapIntensityToAudio (intensity,spookyMixer,"spookyLo","spookyMed","spookyHi");
        MapIntensityToAudio(intensity, lightMixer, "lightLo", "lightMed", "lightHi");
        MapIntensityToAudio(intensity, darkMixer, "darkLo", "darkMed", "darkHi");



        musicSpeed = scale(-1.0f,1.0f,1f,2.0f,intensity);

		musicSpeed = Mathf.Round (musicSpeed * 100) / 100;


		SetChannel ();

		if (intensity > 1) {
			intensity = 1;
		}


		if (hazardlights) {
			masterMixer.SetFloat ("sirenVol", 0);
			        
		} else {
			masterMixer.SetFloat ("sirenVol", -80);
		}


		//int pwr = GameObject.Find ("DashboardController").GetComponent<DashboardInterfaceReader> ().powerButtonState;
		int button1 = GameObject.Find ("DashboardController").GetComponent<DashboardInterfaceReader> ().button1State;
		int button2 = GameObject.Find ("DashboardController").GetComponent<DashboardInterfaceReader> ().button2State;
		int button3 = GameObject.Find ("DashboardController").GetComponent<DashboardInterfaceReader> ().button3State;
		//float lopass= scale(1020, 0,5000,0,GameObject.Find ("DashboardController").GetComponent<DashboardInterfaceReader> ().bass);
		//float hipass= scale(1020, 0,0,5000,GameObject.Find ("DashboardController").GetComponent<DashboardInterfaceReader> ().treble);
        float classVol= scale(1020, 0, 0, -80, GameObject.Find("DashboardController").GetComponent<DashboardInterfaceReader>().bass);
        float neoVol = scale(1020, 0, 0, -80, GameObject.Find("DashboardController").GetComponent<DashboardInterfaceReader>().treble);
        //      float lores;
        //float hires;



        //lopass = 20000;
        //hipass = 0;






        //masterMixer.SetFloat ("lopass", lopass);
        //masterMixer.SetFloat ("hipass", hipass);
        masterMixer.SetFloat ("classVol", classVol);
        masterMixer.SetFloat ("neoVol", neoVol);

    }


    void CorrectPitchOnSpeedChange(){
		float rawSpeed = musicSpeed;
		float rawPitch =  (1.0f/ musicSpeed);

		masterMixer.SetFloat ("rawPitch", rawPitch);
		masterMixer.SetFloat ("rawSpeed", rawSpeed);


		masterMixer.SetFloat ("pitchShifter", pitch);

	}






	void MapIntensityToAudio(float intensity,AudioMixer mixer,string audioLo,string audioMed, string audioHi){
		
		float Lo;
		if (intensity < -0.5f) {
			Lo = 0;
		} else {
			Lo=scale (-0.5f, -0.25f, 0, -80, intensity);

		}

		float Med=-80;
		if (intensity > -0.5f && intensity < 0.5f) {
			Med = 0;
		} else if (intensity < -0.5) {
			Med = (scale (-0.75f, -0.5f, -80, 0, intensity));
		} else if(intensity > 0.5){
			Med= (scale (0.75f, 0.5f, -80, 0, intensity));

		}

		float Hi; 
		if (intensity > 0.5f) {
			Hi = 0;
		}else{
			Hi=scale (0.5f, 0.25f, 0, -80, intensity);

		}


		mixer.SetFloat (audioLo, Lo);
		mixer.SetFloat (audioMed, Med);
		mixer.SetFloat (audioHi, Hi);
		
	}

	void SetChannel(){
		float happyVol=-80;
		float nuetralVol=-80;
		float sadVol=-80;
		float spookyVol=-80;
        float darkVol = -80;
        float lightVol = -80;

        if (channelTune <= 1.5) {
			happyVol = 0;
            sadVol = scale(1, 1.5f, -80, 0, channelTune);
           // nuetralVol =scale (1, 1.5f, -80, 0, channelTune);
			sadVol=-80;
			spookyVol=-80;
		}



        if (channelTune > 1.5f && channelTune <= 4.5f) {
			sadVol = 0;
			happyVol=scale (1.5f, 3f, 0, -80, channelTune);
			spookyVol=scale (3.5f, 4.5f, -80, 0, channelTune);
			nuetralVol=-80;

		}

	
		if (channelTune > 4.5f) {
			sadVol = scale (4.5f, 5, 0, -80, channelTune);
			spookyVol = 0;
			happyVol=-80;
			nuetralVol=-80;

		}


        if (channelTune <= 1.5f)
        {
            lightVol = 0;
            darkVol = -80;
        }

        if (channelTune > 1.5f && channelTune <= 4.5f)
        {
            if (channelTune < 3f)
            {
                lightVol = 0;
                darkVol = scale(1.5f, 3f, -80, 0, channelTune);
            }
            else
            {
                darkVol = 0;
               lightVol = scale(3f, 4.5f, 0, -80, channelTune);
            }

        }


        if (channelTune >= 4.5f)
        {
            lightVol = -80;
            darkVol = 0;
        }

        masterMixer.SetFloat ("upliftingVol", happyVol);
		masterMixer.SetFloat ("nuetralVol", nuetralVol);
		masterMixer.SetFloat ("sadVol", sadVol);
		masterMixer.SetFloat ("spookyVol", spookyVol);
        masterMixer.SetFloat("darkVol", darkVol);
        masterMixer.SetFloat("lightVol", lightVol);






    }


	float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){

		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return(NewValue);
	}






	void MapGasandBrakeToIntensity(){
		float gas = GameObject.Find("DashboardController").GetComponent<DashboardInterfaceReader> ().gas;
		float brake = GameObject.Find("DashboardController").GetComponent<DashboardInterfaceReader> ().brake;
	float acceleration;
	float deacceleration;
	float brakePressure=0;
	float maxIntensity;

		if (brake > 1000) {
			masterMixer.SetFloat ("masterVol", scale (900f, 1020f, -12, -80, brake));
			intensity = -1;
		} else {
			masterMixer.SetFloat ("masterVol", masterVol);
			brakePressure = scale (0f, 1020f, 0f, -.05f, brake);
		}
	

	
		acceleration = scale (0f, 1020f, 0f, 0.01f, gas);

	maxIntensity = scale (0f, 1020f, -1f, 1f, gas);


		deacceleration = -0.001f + acceleration + brakePressure;
	


		//rounding to keep things from getting shaky
		if (intensity > maxIntensity) {
			intensity = intensity + deacceleration ;
		} else {
			intensity = intensity + acceleration;
		}
			
			}
		


	void MapVolumeKnobToPitch(){
		float volumeknob = GameObject.Find("DashboardController").GetComponent<DashboardInterfaceReader> ().volume;
		if (volumeknob < 150) {
			pitch = scale (0, 150, 0.5f, 1, volumeknob);
		} else {
			pitch = scale (150, 1020, 1, 2, volumeknob);
		}
	}

	void MapTunerKnobToMood(){
		float tunerknob= GameObject.Find("DashboardController").GetComponent<DashboardInterfaceReader> ().tune;
        if (tunerknob < 150)
        {
            channelTune = scale(0, 150, 0.5f, 2.5f, tunerknob);
        }else if (tunerknob >= 150&&tunerknob<200) { 
        channelTune =scale (150, 200, 2.5f, 4, tunerknob);
        }
        else if (tunerknob >= 200 )
        {
            channelTune = scale(200, 1020, 4, 5, tunerknob);
        }
    }
}
