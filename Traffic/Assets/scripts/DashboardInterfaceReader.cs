using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class DashboardInterfaceReader : MonoBehaviour {



    AnalogPin[] analogPins;
    int[] digitalPins;
    int[] digitalInput;
    float[] analogInput;


	// Use this for initialization
	public bool usingArduino;


	public int hazardButton=0;
	public int hazardButtonState=1;


	//Radio
	public AnalogPin treblePot = AnalogPin.A5;
	public int treble;
	public AnalogPin bassPot = AnalogPin.A6;
	public int bass;

	public AnalogPin volumePot = AnalogPin.A3;
	public int volume;
	public AnalogPin tunePot = AnalogPin.A2;
	public int tune;

    AnalogPin ignitionPot = AnalogPin.A4;
	public int ignition;

	public int radioLED=7;

    public int button3=6;
	public int button3State=1;

    public int button2=5;
	public int button2State=1;

    public int button1=4;
	public int button1State=1;

    public int powerButton=3;
	public int powerButtonState=1;

    //cruise
    public int cruiseButton=38;
	public int cruiseButtonState=1;

    //pedals
    public AnalogPin gasPot = AnalogPin.A0;
	public int gas;
    public AnalogPin brakePot = AnalogPin.A1;
	public int brake;


	//steering wheel

	//const int clkPin=52; 
	//int newA;
	//int oldA;
	//const int dtPin= 50; 
	//const int swPin= 48;
	public float steeringWheel;





	//MIRROR CONTROLS

	//public string MirrorButton = "UP";
	//public string MirrorSwitch = "M";

	//public int Aoutput = 33;
	//public int Binput = 35;
 //   public int Cinput = 39;
 //   public int Xinput = 37;
 //   public int Youtput = 31;

 //   public int Rinput = 29;
 //   public int Linput = 27;

	//int AState = 0;
	//int BState = 0;
	//int CState = 0;
	//int XState = 0;
	//int YState = 0;

	//int RState = 0;
	//int LState = 0;
 



	void Start () {
        ConfigurePins();
        hazardButtonState= digitalInput[System.Array.IndexOf(digitalPins, hazardButton)];
        //if (usingArduino) {
        //          //arduino = Arduino.global;
        //          ConfigurePins();
        //}
    }
	
	// Update is called once per frame
	void Update () {

       


		//if (usingArduino) {

			//SetSteeringWheel (3);
			//SetMirror ();






			//treble = arduino.analogRead (treblePot);
			//bass = arduino.analogRead (bassPot);

			//volume = arduino.analogRead (volumePot);
			//tune = arduino.analogRead (tunePot);

			//ignition = arduino.analogRead (ignitionPot);




			//hazardButtonState = arduino.digitalRead (hazardButton);

			//button1State = arduino.digitalRead (button1);
			//button2State = arduino.digitalRead (button2);
			//button3State = arduino.digitalRead (button3);
			//powerButtonState = arduino.digitalRead (powerButton);

			//cruiseButtonState = arduino.digitalRead (cruiseButton);



			//gas = arduino.analogRead (gasPot);
			//brake = arduino.analogRead (brakePot);

			//oldA = arduino.digitalRead (clkPin);

		}

    void ConfigurePins()
    {

    }
    void ConfigureAnalog(int _pin, float _val)
    {

    }

}

	//	void ConfigurePins( )
	//{

	//	ConfigureAnalog (treblePot);
	//	ConfigureAnalog (bassPot);

	//	ConfigureAnalog (volumePot);
	//	ConfigureAnalog (tunePot);

	//	ConfigureAnalog (ignitionPot);

	//	ConfigureButton (hazardButton);

	//	ConfigureButton (button3);
	//	ConfigureButton (button2);
	//	ConfigureButton (button1);
	//	ConfigureButton (powerButton);


	//	ConfigureButton (cruiseButton);

	//	ConfigureAnalog (gasPot);
	//	ConfigureAnalog (brakePot);

	////steering wheel encoder
	//	ConfigureButton (clkPin);
	//	ConfigureButton (dtPin);


	//	ConfigureOutput (Youtput);
	//	ConfigureOutput (Aoutput);
	//	ConfigureButton (Binput);
	//	ConfigureButton (Cinput);
	//	ConfigureButton (Xinput);
	//	ConfigureButton (Linput);
	//	ConfigureButton (Rinput);

	//	//oldA = arduino.digitalRead (clkPin);





	//}



	//void ConfigureAnalog(int pin){
	//	arduino.pinMode(pin, PinMode.ANALOG);
	//	arduino.reportAnalog(pin, 1);
	//}

	//void ConfigureButton(int pin){
	//	arduino.pinMode(pin, PinMode.INPUT);
	//	arduino.reportDigital((byte)(pin/8), 1);
	//	arduino.digitalWrite (pin, 1);
		
	//}

	//void ConfigureOutput(int pin){
	//	arduino.pinMode(pin, PinMode.OUTPUT);
	//	arduino.reportDigital((byte)(pin/8), 1);
	//	arduino.digitalWrite (pin, 0);

	//}





	//void SetSteeringWheel (int maxRotation){
	//	newA = arduino.digitalRead (clkPin);
	//	if (newA != oldA) {
	//		if (arduino.digitalRead (dtPin) != newA) {
	//			steeringWheel++;
	//		} else {
	//			steeringWheel--;
	//		}
	//	}
	//	oldA = newA;

	//	if (steeringWheel > maxRotation) {
	//		steeringWheel = maxRotation;
	//	}else if(steeringWheel< -maxRotation){
	//		steeringWheel = -maxRotation;
	//	}
	//}


	//void SetMirror (){
	//	//AState = arduino.digitalRead(Aoutput);
	//	//CState = arduino.digitalRead(Cinput);
	//	//BState = arduino.digitalRead(Binput);
	//	//XState = arduino.digitalRead(Xinput);
	//	//YState = arduino.digitalRead(Youtput);
	//	//RState = arduino.digitalRead(Rinput);
	//	//LState = arduino.digitalRead(Linput);

	//	if(LState==0){
	//		MirrorSwitch = "L";
	//	}else if(RState==0){
	//		MirrorSwitch = "R";
	//	}else{
	//		MirrorSwitch = "M";
	//	}


	//	if (CState == 0 && BState == 0) {

	//		MirrorButton = "UP";
	//	} else if (BState == 0) {
	//		//UpmirrorPressed
	//		MirrorButton = "RIGHT";
	//	} else if (XState == 0) {
	//		MirrorButton = "LEFT";
	//	} else{
	//		MirrorButton = "OFF";
	//	}

		
	//}




