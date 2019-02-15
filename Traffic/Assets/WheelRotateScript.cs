using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotateScript : MonoBehaviour
{

    public GameObject Car;
    TrafficScript traffic;
    // Start is called before the first frame update
    void Start()
    {

        traffic = Car.GetComponent<TrafficScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed= Car.GetComponent<TrafficScript>().speed;

        transform.Rotate(-speed, 0, 0);
    }
}
