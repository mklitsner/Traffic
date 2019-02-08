// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;
using System;

public class OSCReciever_CSHARP : MonoBehaviour
{

    public string RemoteIP = "127.0f.0.1f"; //127.0f.0.1f signifies a local host (if testing locally
    public int SendToPort = 9000; //the port you will be sending from
    public int ListenerPort = 8000; //the port you will be listening on
    public Transform controller;
    public string gameReceiver = "Cube"; //the tag of the object on stage that you want to manipulate
    private Osc handler;
    public int messageNum;
    public float Message;
    public bool usingOSC;

    //VARIABLES YOU WANT TO BE ANIMATED
    //private float xRot = 0; //the rotation around the x axis
    private float yRot = 0; //the rotation around the y axis
    //private float zRot = 0; //the rotation around the z axis
    //private float scaleVal = 1;
    //private float xVal = 0;

    //private int scaleValX = 1;
    //private int scaleValY = 1;
    //private int scaleValZ = 1;

    public void Start()
    {
        //Initializes on start up to listen for messages
        //make sure this game object has both UDPPackIO and OSC script attached

        UDPPacketIO udp = GetComponent <UDPPacketIO> ();
        udp.init(RemoteIP, SendToPort, ListenerPort);
        handler = GetComponent < Osc> ();
        handler.init(udp);
        handler.SetAllMessageHandler(AllMessageHandler);
        Debug.Log("Running");
        if (!usingOSC)
        {
            Debug.Log("OSC Deactivated");
        }
    }
   

void Update()
    {
        if (usingOSC)
        {
            GameObject go = GameObject.Find(gameReceiver);
            //_VAR_TYPE go2= GameObject.Find(gameReceiver2);
            //go.transform.Rotate(xRot, yRot, zRot);

            float yDeg = yRot * 180 / 3.14159265359f;
            //Debug.Log(yDeg);


            if (yDeg > 360)
            {
                Debug.Log("ANAMOLY");
            }
            else
            {
                Vector3 V3 = new Vector3(0, yDeg, 0);

                if (go == null)
                {

                }
                else
                {
                    go.transform.eulerAngles = V3;

                }

                Message = yDeg;
            }
        }
       

        //go.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
        //go.transform.Translate(xVal,0,0,Space.World);
        //go2.transform.localScale = new Vector3(scaleValX,scaleValY,scaleValZ);
    }

    //These functions are called when messages are received
    //Access values via: oscMessage.Values[0], oscMessage.Values[1], etc

    public void AllMessageHandler(OscMessage oscMessage)
    {
     

        string msgString = Osc.OscMessageToString(oscMessage); //the message and value combined
       string msgAddress = oscMessage.Address; //the message parameters
        object msgValue = oscMessage.Values[messageNum]; //the  message value
                                                         //Debug.Log(msgValue); //log the message and values coming from OSC

        //FUNCTIONS YOU WANT CALLED WHEN A SPECIFIC MESSAGE IS RECEIVED
        if(oscMessage.Values.Count>2){
            Rotate(Convert.ToSingle(msgValue));
        }else{
            Debug.Log(msgString);
        }

        //Debug.Log(msgString);
        //Debug.Log(msgValue);

    }


    //FUNCTIONS CALLED BY MATCHING A SPECIFIC MESSAGE IN THE ALLMESSAGEHANDLER FUNCTION
    public void Rotate(float _msgValue) //rotate the cube around its axis
{
    yRot = _msgValue;
    //Debug.Log(yRot);
}
}

