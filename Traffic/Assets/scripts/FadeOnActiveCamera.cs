using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOnActiveCamera : MonoBehaviour
{

   


    public void SetActiveCamera(GameObject _activeCamera)
    {
        GetComponent<Canvas>().worldCamera = _activeCamera.GetComponent<Camera>(); ;
    }
}
