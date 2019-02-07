using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;


public class ArduinoReader : MonoBehaviour
{

    public float[] potValue;
    public AnalogPin[] pinsPots;

    public int[] pinsButtons;

    public int[] buttonValue;
 


    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < pinsPots.Length; i++)
        {
            UduinoManager.Instance.pinMode(pinsPots[i], PinMode.Input);
        }
      

        for (int i = 0; i < pinsButtons.Length; i++)
        {
            UduinoManager.Instance.pinMode(pinsButtons[i], PinMode.Input_pullup);
        }


    }

    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < potValue.Length; i++)
        {
            //potValue[i] = UduinoManager.Instance.analogRead(pinsPots[i]);
            potValue[i] = UduinoManager.Instance.analogRead(pinsPots[i],"ReadPot");
        }
        UduinoManager.Instance.SendBundle("ReadPot");


        for (int i = 0; i < buttonValue.Length; i++)
        {
            buttonValue[i] = UduinoManager.Instance.digitalRead(pinsButtons[i]);
            //buttonValue[i] = UduinoManager.Instance.analogRead(pinsButtons[i], "ReadButton");
        }


        //UduinoManager.Instance.SendBundle("ReadButton");




        //potValue[0] = UduinoManager.Instance.analogRead(-10);


    }
}
