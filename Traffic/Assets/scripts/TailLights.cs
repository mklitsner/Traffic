using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailLights : MonoBehaviour {



	// Use this for initialization

	// Update is called once per frame
	void Update () {
        if (transform.parent.parent == null)
        {

        }
        else
        {


            if (transform.parent.parent.GetComponent<Traffic>().speed < 0.03)
            {

                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);

                print("brakesOn");
            }
            else
            {
                print("brakesOn");
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);

            }
        }
	}
}
