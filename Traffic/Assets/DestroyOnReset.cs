using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnReset : MonoBehaviour
{

    /// <summary>
    /// Destroy children on reset
    /// </summary>

    StageManagerScript StageManager;

    void Start()
    {
        StageManager = GameObject.Find("Managers").GetComponent<StageManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StageManager.resetRide)
        {
            for(int i=0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
