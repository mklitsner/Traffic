using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetPosition : MonoBehaviour
{


    StageManagerScript StageManager;
    Pose startPose;
    void Start()
    {
        StageManager = GameObject.Find("Managers").GetComponent<StageManagerScript>();
        startPose.rotation = transform.rotation;
        startPose.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (StageManager.resetRide)
        {
            transform.position = startPose.position;
            transform.rotation = startPose.rotation;
        }
    }
}
