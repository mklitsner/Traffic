using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool resetRide;

    InitializeRideScript IRS;
    // Update is called once per frame

    private void Start()
    {
        IRS = GameObject.Find("DigitalDashboardController").GetComponent<InitializeRideScript>();
    }
    void Update()
    {
        resetRide = false;
        if (IRS.rideOn ==false)
        {
            ResetRide();
        }
    }

    void ResetRide()
    {
        resetRide = true;
    }
}
