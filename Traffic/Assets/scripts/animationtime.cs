using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationtime : MonoBehaviour {
	Animation anim;
	private float animSpeed;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		anim = GetComponent<Animation>();
		anim["loop"].speed = animSpeed;

		animSpeed = GameObject.Find ("DigitalDashBoardController").GetComponent<DashboardOutput> ().intensity;


	

		
	}
}
