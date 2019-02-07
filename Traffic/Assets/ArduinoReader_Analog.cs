using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;


public class ArduinoReader_Analog : MonoBehaviour
{

    public float[] potValue;
    public AnalogPin[] pinsPots;

  


    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < pinsPots.Length; i++)
        {
            UduinoManager.Instance.pinMode(pinsPots[i], PinMode.Input);
        }


    }

    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < potValue.Length; i++)
        {
            potValue[i] = UduinoManager.Instance.analogRead(pinsPots[i]);
        }



  

        //potValue[0] = UduinoManager.Instance.analogRead(-10);


    }
}
