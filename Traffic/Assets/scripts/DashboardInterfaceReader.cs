using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class DashboardInterfaceReader : MonoBehaviour {


   public GameObject OscUduinoObject;
    ArduinoReader OUO;
    OSCReciever_CSHARP ORC;

    int[] ButtonVals;
    int[] PotVals;


	// Use this for initialization
	public bool usingArduino;


	public int hazardButtonPin=2;
    public int hazardButtonElement;
	public int hazardButtonState=1;


	//Radio
	public AnalogPin treblePot = AnalogPin.A5;
	public int treble;
    public int trebleElement;
    public AnalogPin bassPot = AnalogPin.A6;
	public int bass;
    public int bassElement;

    public AnalogPin volumePot = AnalogPin.A3;
	public int volume;
    public int volumeElement;

    public AnalogPin tunePot = AnalogPin.A2;
	public int tune;
    public int tuneElement;

    public int ignitionPin = 13;
	public int ignitionState=0;
    public int ignitionElement;

    public int button3Pin=6;
	public int button3State=1;
    public int button3Element;

    public int button2Pin = 5;
	public int button2State=1;
    public int button2Element;

    public int button1Pin = 4;
	public int button1State=1;
    public int button1Element;

    public int powerButtonPin = 3;
	public int powerButtonState=1;
    public int powerButtonElement;

    //cruise
    public int cruiseButtonPin = 38;
	public int cruiseButtonState=1;
    public int cruiseButtonElement;

    

    //pedals
    public AnalogPin gasPot = AnalogPin.A0;
	public int gas;
    public int gasElement;
    public AnalogPin brakePot = AnalogPin.A1;
	public int brake;
    public int brakeElement;



	public float steeringWheel;



	void Start () {


       OUO= OscUduinoObject.GetComponent<ArduinoReader>();
        ORC= OscUduinoObject.GetComponent<OSCReciever_CSHARP>();
        int[] PinsButtons = OUO.pinsButtons;
        AnalogPin[] PinsPots = OUO.pinsPots;

        hazardButtonElement = GetPin(PinsButtons, hazardButtonPin);
        ignitionElement = GetPin(PinsButtons, ignitionPin);
        button1Element = GetPin(PinsButtons, button1Pin);
        button2Element = GetPin(PinsButtons, button2Pin);
        button3Element = GetPin(PinsButtons, button3Pin);
        powerButtonElement = GetPin(PinsButtons, powerButtonPin);
        cruiseButtonElement = GetPin(PinsButtons, cruiseButtonPin);

        trebleElement = GetAnalogPin(PinsPots, treblePot);
        bassElement = GetAnalogPin(PinsPots, bassPot);
        volumeElement = GetAnalogPin(PinsPots, volumePot);
        tuneElement = GetAnalogPin(PinsPots, tunePot);
        gasElement = GetAnalogPin(PinsPots, gasPot);
        brakeElement = GetAnalogPin(PinsPots, brakePot);


 
    }
	
	// Update is called once per frame
	void Update () {
        ButtonVals = OUO.buttonValue;
        PotVals = OUO.potValue;
        if (ORC.usingOSC)
        {
            steeringWheel = ORC.Message;

        }
       

        hazardButtonState = ButtonVals[hazardButtonElement];
        ignitionState = ButtonVals[ignitionElement];
        button1State = ButtonVals[button1Element];
        button2State = ButtonVals[button2Element];
        button3State = ButtonVals[button3Element];
        powerButtonState = ButtonVals[powerButtonElement];
        cruiseButtonState = ButtonVals[cruiseButtonElement];

        treble = PotVals[trebleElement];
        bass = PotVals[bassElement];
        volume = PotVals[volumeElement];
        tune = PotVals[tuneElement];
        gas = PotVals[gasElement];
        brake = PotVals[brakeElement];

        

    }

    public int GetPin(int[] _Pins, int _pin)
    {
        int keyPinNumber = 0;
        for(int i=0; i < _Pins.Length; i++)
        {
            if (_Pins[i]==_pin)
            {
                keyPinNumber = i;
            }
                
        }
        return keyPinNumber;
    }




    public int GetAnalogPin(AnalogPin[] _Pins, AnalogPin _pin)
    {
        int keyPinNumber = 0;
        for (int i = 0; i < _Pins.Length; i++)
        {
            if (_Pins[i] == _pin)
            {
                keyPinNumber = i;
            }

        }
        return keyPinNumber;
    }

    


}

	




