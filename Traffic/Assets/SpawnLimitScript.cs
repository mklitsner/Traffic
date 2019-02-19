using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLimitScript : MonoBehaviour
{

    public int spawnLimit=30;
    public bool overLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > spawnLimit)
        {
            overLimit = true;
        }


        if (overLimit)
        {
            //select random object in child count
            Transform unluckyOne = transform.GetChild(Random.Range(0, transform.childCount));

            //if object has disintegrate script, activate it
            if (unluckyOne.gameObject.GetComponent<DeColliderandDestroy>() != null)
            {
                unluckyOne.gameObject.GetComponent<DeColliderandDestroy>().disable = true;
            }
        }
    }
}
