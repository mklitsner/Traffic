using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjectScript : MonoBehaviour
{
    public GameObject[] ends;
    public GameObject[] starts;
    public string portaltype;

    // Start is called before the first frame update
    void Start()
    {
        if (portaltype != "master")
        {
            ends = transform.parent.GetComponent<TeleportObjectScript>().ends;
            starts = transform.parent.GetComponent<TeleportObjectScript>().starts;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (portaltype == "end")
        {
            //send object to a randomstart
        }
    }

}
