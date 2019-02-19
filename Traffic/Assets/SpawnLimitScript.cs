using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLimitScript : MonoBehaviour
{

    public int spawnLimit=30;
    public bool overLimit;
    bool ready=true;
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
        else
        {
            overLimit = false;
        }


        if (overLimit )
        {
            Transform unluckyOne = transform.GetChild(Random.Range(0, transform.childCount));
            if (unluckyOne.gameObject.GetComponent<DeColliderandDestroy>() != null)
            {
                unluckyOne.gameObject.GetComponent<DeColliderandDestroy>().disable = true;
            }
            //select random object in child count
            //if (ready)
            //{
            //    //StartCoroutine("WaitToDisable");
            //    //if object has disintegrate script, activate it
            //}
        }
        else
        {
            //StopCoroutine("WaitToDisable");
        }
    }

    IEnumerator WaitToDisable()
    {

        ready = false;
      
        yield return new WaitForSecondsRealtime(0.2f);
        ready = true;

    }
}
