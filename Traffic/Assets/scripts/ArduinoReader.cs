using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;


public class ArduinoReader : MonoBehaviour
{

    public int[] potValue;
    public AnalogPin[] pinsPots;

    public int[] pinsButtons;

    public int[] buttonValue;

    public bool usingArduino;

    // Use this for initialization
    void Start()
    {
        if (usingArduino)
        {
            for (int i = 0; i < pinsButtons.Length; i++)
            {
                UduinoManager.Instance.pinMode(pinsButtons[i], PinMode.Input_pullup);
            }

            for (int i = 0; i < pinsPots.Length; i++)
            {
                UduinoManager.Instance.pinMode(pinsPots[i], PinMode.Input);
            }


          
        }
        else
        {
            Debug.Log("Arduino Deactivated");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (usingArduino)
        {

           
           

            for (int i = 0; i < buttonValue.Length; i++)
            {
                buttonValue[i] = UduinoManager.Instance.digitalRead(pinsButtons[i]);
                //buttonValue[i] = UduinoManager.Instance.analogRead(pinsButtons[i], "ReadButton");
            }
            

            for (int i = 0; i < potValue.Length; i++)
            {
                //potValue[i] = UduinoManager.Instance.analogRead(pinsPots[i]);
                potValue[i] = UduinoManager.Instance.analogRead(pinsPots[i], "ReadPot");
            }
            UduinoManager.Instance.SendBundle("ReadPot");
        }
        //UduinoManager.Instance.SendBundle("ReadButton");




        //potValue[0] = UduinoManager.Instance.analogRead(-10);


    }
}
