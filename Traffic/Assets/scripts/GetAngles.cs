using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAngles : MonoBehaviour {
    Vector3 AccData;
    Vector3 newAngles;
    public float xAngle;
    public float yAngle;
    public float zAngle;
    // Use this for initialization
    void Start () {
       
     
}
	
	// Update is called once per frame
	void Update () {
        AccData = this.transform.position;
        float ax = AccData.x;
        float ay = AccData.y;
        float az = AccData.z;

        xAngle = Mathf.Atan(ax / (Mathf.Sqrt(Mathf.Pow(ay,2) + Mathf.Pow(az, 2))));
         yAngle = Mathf.Atan(ay / (Mathf.Sqrt(Mathf.Pow(ax, 2) + Mathf.Pow(az, 2))));
         zAngle = Mathf.Atan(Mathf.Sqrt(Mathf.Pow(ax, 2) + Mathf.Pow(ay, 2)) / az);

        xAngle *= 180.00f; yAngle *= 180.00f; zAngle *= 180.00f;
        xAngle /= Mathf.PI; yAngle /= Mathf.PI; zAngle /= Mathf.PI;

        //if(zAngle<0){
        //    xAngle -= 180;
        //    xAngle *= -1;

        //}

        newAngles = new Vector3(xAngle, 0, 0);
        //transform.eulerAngles=newAngles;
        transform.localEulerAngles= newAngles;
        
    }
}
