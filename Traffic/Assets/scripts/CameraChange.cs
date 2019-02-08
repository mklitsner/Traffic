using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CameraChange : MonoBehaviour {
//	private string mirrorButton;
//	private string mirrorSwitch;
//	private int wheelPos;

	public GameObject DashBoard;
	public GameObject Arduino;

	private int currentAngle =0;
	private GameObject[] angles;

	public int currentShot =0;
	private Transform[] shots;

	public int currentScene =0;
	private Transform[] scenes;

	bool pressleft;
	bool pressup;
	bool pressright;
	public bool wheelTurned;
    public float wheelTurnIncrement=10;
    public float wheelNuetralRange;
    int wheelDir;

	public bool testingArduino;
	float counter;

	public Color happyColor;
	public Color sadColor;
	public Color spookyColor;
	Color skyColor;


    float lastWheelPos;


	// Use this for initialization
	void Start () {


       




    }
	
	// Update is called once per frame
	void Update () {



		
		//string mirrorButton =DashBoard.GetComponent<DashboardInterfaceReader> ().MirrorButton;
		//string	mirrorSwitch=DashBoard.GetComponent<DashboardInterfaceReader> ().MirrorSwitch;
		float wheelPos=DashBoard.GetComponent<DashboardInterfaceReader> ().steeringWheel;
		int cruiseButton=DashBoard.GetComponent<DashboardInterfaceReader> ().cruiseButtonState;

		 



		scenes = new Transform[transform.childCount];

		for (int s = 0; s < scenes.Length; s++) {
			scenes [s] = transform.GetChild (s).transform;

			shots = new Transform[scenes [s].childCount];

			for (int i = 0; i < shots.Length; i++) {
				shots [i] = scenes [s].GetChild (i).transform;

				angles = new GameObject[shots [i].childCount];

				for (int a = 0; a < angles.Length; a++) {
					angles [a] = shots [i].GetChild (a).gameObject;
					if (currentScene == s) {
						if (currentShot == i) {
							if (currentAngle == a) {
								angles [a].SetActive (true);
								angles [a].GetComponent<BloomOptimized> ().threshold
								=GetComponent<BloomOptimized> ().threshold;
								angles [a].GetComponent<BloomOptimized> ().intensity
								=GetComponent<BloomOptimized> ().intensity;
								angles [a].GetComponent<VignetteAndChromaticAberration> ().intensity
								=GetComponent<VignetteAndChromaticAberration> ().intensity;

								angles [a].GetComponent<VignetteAndChromaticAberration> ().chromaticAberration
								=GetComponent<VignetteAndChromaticAberration> ().chromaticAberration;




								if (cruiseButton == 0) {
									angles [a].GetComponent<CameraBehavior> ().followTarget=true;
								} else {
									angles [a].GetComponent<CameraBehavior> ().followTarget=false;

									if (pressup) {

										angles [a].transform.Translate (0, 0, 0);
									} else if (pressleft) {
										angles [a].transform.Translate (0, 0, scale (-1, 1, 0.01f, 0.2f, Arduino.GetComponent<DashboardOutput> ().intensity));
									} else if (pressright) {
										angles [a].transform.Translate (0, 0, scale (-1, 1, -0.01f, -0.2f, Arduino.GetComponent<DashboardOutput> ().intensity));
									}
								}



							} else {
								angles [a].SetActive (false);
							}
						
						} else {
							angles [a].SetActive (false);
						}

					} else {
						angles [a].SetActive (false);
					}
				}
			}
		}


		if (testingArduino) {
			//currentShot = 0;

			if (currentAngle < 0) {
				currentAngle=angles.Length-1;
			}if (currentAngle > angles.Length-1) {
				currentAngle = 0;
			}

			if (wheelTurned == false) {

				if (wheelPos-lastWheelPos < -wheelTurnIncrement) {
					wheelTurned = true;
					currentAngle--;
                    lastWheelPos = wheelPos;
                    wheelDir = -1;
                    print("turn left");
                    StartCoroutine("WaitforWheelTurn");
                }
				if (wheelPos- lastWheelPos > wheelTurnIncrement) {
					wheelTurned = true;
					currentAngle++;
                    lastWheelPos = wheelPos;
                    print("turn right");
                    wheelDir = 1;
                    StartCoroutine("WaitforWheelTurn");
                }
                //check if wheel is back in neutral position
			} else if(wheelTurned == true){
                if (wheelPos < 180+0.5 * wheelNuetralRange && wheelPos > 180 - 0.5 * wheelNuetralRange) {
					wheelTurned = false;
                    print("return to nuetral");
                    StopCoroutine("WaitforWheelTurn");
                    wheelDir = 0;

                }
			}



			//if (mirrorSwitch == "L") {

			//	currentScene = 2;
			//}else if (mirrorSwitch == "M") {

			//	currentScene = 1;
			//}else if (mirrorSwitch == "R") {

			//	currentScene = 0;
			//}


			//if (mirrorButton == "LEFT") {
			//	pressleft = true;
			//	pressright = false;
			//	pressup = false;
			//} else if (mirrorButton == "UP") {
			//	pressup = true;
			//	pressleft = false;
			//	pressright = false;
			//} else if (mirrorButton == "RIGHT") {
			//	pressright = true;
			//	pressleft = false;
			//	pressup = false;
			//} else if (mirrorButton == "OFF") {

			//}
		}





		ManipulateSkyBox ();

	
		GetComponent<VignetteAndChromaticAberration> ().intensity = scale (4, 5, 0, 0.16f, Arduino.GetComponent<DashboardOutput> ().channelTune);

		if (GetComponent<VignetteAndChromaticAberration> ().intensity < 0) {
			GetComponent<VignetteAndChromaticAberration> ().intensity = 0;
		}
			


		//print (" shot:"+currentShot+" angle:"+currentAngle+" scene:"+currentScene);

		
	}

    IEnumerator WaitforWheelTurn()
    {
        yield return new WaitForSeconds(1);
        currentAngle+=wheelDir;
        StartCoroutine("WaitforWheelTurn");
    }
    



	void ManipulateSkyBox(){
		float channeltune=Arduino.GetComponent<DashboardOutput> ().channelTune;
		float intensity=Arduino.GetComponent<DashboardOutput> ().intensity;

		if (channeltune <= 3) {
			skyColor = Color.Lerp (happyColor, sadColor, scale (1, 3, 0, 1, channeltune));
		} else if (channeltune > 3) {
			skyColor = Color.Lerp (sadColor, spookyColor, scale (3, 5, 0, 1, channeltune));
		}

		GetComponent<Skybox> ().material.SetColor ("_SkyTint", skyColor);
		GetComponent<Skybox> ().material.SetFloat ("_Exposure", scale (5, 1, 0.2f, 2.5f, channeltune));
		GetComponent<Skybox> ().material.SetFloat ("_AtmosphereThickness", scale (-1,1, 1.0f, 1.8f, intensity));
	}


	float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){

		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return(NewValue);
	}
		}
	

