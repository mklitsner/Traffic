using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeColliderandDestroy : MonoBehaviour
{

    CarEngine carEngine;
    public bool disable;
    public MeshCollider meshCollider;
    // Start is called before the first frame update
    void Start()
    {
        carEngine = GetComponent<CarEngine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disable)
        {
           for(int i=0; i < carEngine.wheelcollider.Length; i++)
            {
                carEngine.wheelcollider[i].enabled = false;
            }
            meshCollider.enabled = false;

        }



    }




}
