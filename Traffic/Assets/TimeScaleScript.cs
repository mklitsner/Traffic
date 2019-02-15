using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float intensity = GetComponent<DashboardOutput>().intensity;
        float slowMoSpeed = scale(-1, 1, 0.1f, 4, intensity);
        Time.timeScale = slowMoSpeed;

        Time.fixedDeltaTime = slowMoSpeed * 0.02f;
    }
    float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }
}
