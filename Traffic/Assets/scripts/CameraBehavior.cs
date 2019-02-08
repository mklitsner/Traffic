using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {


	public Transform target;

	//if checked off, the camera will appear near the target but will not follow it
	public bool followTarget;

	public float xOffset;
	public float yOffset;
	public float zOffset;

	Vector3 initialOffset;

	Vector3 OriginalPosition;



	public float randomizeRange;

	float randomValue;

	// Use this for initialization

	void Start(){

		OriginalPosition = transform.position;

        if (target == null)
        {

        }
        else
        {
            initialOffset = new Vector3(
                transform.position.x - target.position.x,
                transform.position.y - target.position.y,
                transform.position.z - target.position.z);
        }
	}


	void OnEnable () {


        if (target == null)
        {

        }
        else
        {
            initialOffset = new Vector3(
            transform.position.x - target.position.x,
            transform.position.y - target.position.y,
            transform.position.z - target.position.z);
           
            xOffset = initialOffset.x;
            yOffset = initialOffset.y;
            zOffset = initialOffset.z;

            randomValue = Random.Range(-randomizeRange, randomizeRange);

            transform.position = new Vector3(
                target.position.x + xOffset + randomValue,
                target.position.y + yOffset + randomValue,
                target.position.z + zOffset + randomValue);

            transform.LookAt(target);

        }







    }
	
	// Update is called once per frame
	void FixedUpdate() {
        if (target == null) { }
        else
        {


            if (followTarget)
            {
                transform.LookAt(target);
                transform.position = new Vector3(
                    target.position.x + xOffset + randomValue,
                    target.position.y + yOffset + randomValue,
                    target.position.z + zOffset + randomValue);
            }

        }
	
		
	}
	void OnDisable (){
		if (target == null) {
			transform.position = OriginalPosition;
		}
		
		
	}

}
