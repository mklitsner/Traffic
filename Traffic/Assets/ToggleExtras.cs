using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleExtras : MonoBehaviour
{

    public bool ArduinoAndOscAllOn;
    public bool ArduinoAndOscAllOff;

    // Start is called before the first frame update
    void Start()
    {
        if (ArduinoAndOscAllOn)
        {
            GameObject.Find("OSC UDUINO Script Object").GetComponent<ArduinoReader>().usingArduino = true;
            GameObject.Find("OSC UDUINO Script Object").GetComponent<OSCReciever_CSHARP>().usingOSC = true;
            GameObject.Find("DashboardController").GetComponent<DashboardInterfaceReader>().usingArduino = true;
            GameObject.Find("DigitalDashboardController").GetComponent<DashboardOutput>().testingOnArduino = true;
        }
        if (ArduinoAndOscAllOff)
        {
            GameObject.Find("OSC UDUINO Script Object").GetComponent<ArduinoReader>().usingArduino = false;
            GameObject.Find("OSC UDUINO Script Object").GetComponent<OSCReciever_CSHARP>().usingOSC = false;
            GameObject.Find("DashboardController").GetComponent<DashboardInterfaceReader>().usingArduino = false;
            GameObject.Find("DigitalDashboardController").GetComponent<DashboardOutput>().testingOnArduino = false;
        }

    }

}
