using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBugPath : MonoBehaviour
{
    CarEngine carEngine;
    public string attackPathname;
    public string peacePathname;
    Transform attackPath;
    Transform peacePath;
    [SerializeField]
    string currentPath;
    DashboardOutput DO;

    [SerializeField]
    float tunerThreshold;

    // Start is called before the first frame update
    void Start()
    {
        carEngine = GetComponent<CarEngine>();
        DO = GameObject.Find("DigitalDashboardController").GetComponent<DashboardOutput>();
        attackPath = GameObject.Find(attackPathname).transform;
        peacePath = GameObject.Find(peacePathname).transform;

    }

    // Update is called once per frame
    void Update()
    {

        //if the hazards go on and the tone is dark, attack
        if(DO.hazardlights == true)
        {
            if (currentPath != attackPathname)
            {


                carEngine.SetPath(attackPathname, Random.Range(0, attackPath.childCount));
                //trigger change to bug
                currentPath = attackPathname;
            }
        }
        //if tone is light, romp around
        if (DO.hazardlights == false )
        {
            if (currentPath != peacePathname)
            {
                carEngine.SetPath(peacePathname, Random.Range(0, peacePath.childCount));
                //trigger change back to car
                currentPath = peacePathname;
            }
        }

        //otherwise, exit the field
    }
}
