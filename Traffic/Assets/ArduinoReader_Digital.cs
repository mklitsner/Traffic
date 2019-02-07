using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;


public class ArduinoReader_Digital : MonoBehaviour
{


    public int[] pinsButtons;

    public int[] buttonValue;
 


    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < pinsButtons.Length; i++)
        {
            UduinoManager.Instance.pinMode(pinsButtons[i], PinMode.Input_pullup);
        }


    }

    // Update is called once per frame
    void Update()
    {




        for (int i = 0; i < buttonValue.Length; i++)
        {
            buttonValue[i] = UduinoManager.Instance.digitalRead(pinsButtons[i]);
        }

     

  

        //potValue[0] = UduinoManager.Instance.analogRead(-10);


    }
}
