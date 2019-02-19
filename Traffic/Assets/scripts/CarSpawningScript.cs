using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawningScript : MonoBehaviour {
	public GameObject Arduino;
    public GameObject SpawnHolder;
	public Transform[] spawns;
	public float spawnFrequency;
	public float spawnSpeed;
	public float timeSinceLastSpawn;
	public int spawnRatio;
	float intensity;
	float channel;

	public GameObject[] cars;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		intensity = Arduino.GetComponent<DashboardOutput> ().intensity;
		channel = Arduino.GetComponent<DashboardOutput> ().channelTune;

		//spawnFrequency = scale (-1, 1, 5, 1,intensity);

		spawns = new Transform[transform.childCount];

		timeSinceLastSpawn=timeSinceLastSpawn+Time.deltaTime;

		if (timeSinceLastSpawn >= spawnFrequency) {
			timeSinceLastSpawn = 0;

			for(int i = 0; i < spawns.Length; i++) {
				spawns [i] = transform.GetChild (i).transform;

				int carLength = cars.Length;

				if(Random.Range(0,spawnRatio)==0){
                    if (spawns[i].GetComponent<CollidedWithObject>().occupied)
                    {

                    }
                    else
                    {


                        GameObject newCar = Instantiate(cars[Random.Range(0, carLength)]);

                        //newCar.transform.position=new Vector3 (spawns[i].position.x,newCar.transform.position.y,spawns[i].position.z);
                        newCar.transform.position = spawns[i].position;
                        newCar.transform.rotation = spawns[i].rotation;
                        if (newCar.GetComponent<TrafficScript>() != null)
                        {
                            newCar.GetComponent<TrafficScript>().speedmultiplier = Random.Range(spawnSpeed, spawnSpeed + 0.01f);
                        }
                        if (newCar.GetComponent<Renderer>() != null)
                        {
                            newCar.GetComponent<Renderer>().material.SetColor("_CarColor", new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f)));
                        }
                        newCar.transform.SetParent(SpawnHolder.transform); 
                    }
				}
				}

			}




			}
		
			
	float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){

		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return(NewValue);
	}
}
