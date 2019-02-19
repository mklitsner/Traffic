using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeRideScript : MonoBehaviour
{
    public float fadeLength=1.5f;
    DashboardInterfaceReader DIR;
    DashboardOutput DO;
    CanvasFadeScript CFS;
    Scene scene;
    bool end=true;
    bool start;
    void Awake()
    {
        DIR = GameObject.Find("DashboardController").GetComponent<DashboardInterfaceReader>();
        DO= GameObject.Find("DigitalDashboardController").GetComponent<DashboardOutput>();
        scene = SceneManager.GetActiveScene();
        CFS = GameObject.Find("Canvas").GetComponent<CanvasFadeScript>();   
        Debug.LogWarning("loading " + scene.name);
    }

    void OnSceneLoaded(Scene _scene)
    {

        scene = _scene;
        CFS = GameObject.Find("Canvas").GetComponent<CanvasFadeScript>();
        Debug.LogWarning("loading " + scene.name);
    }

    void Update()
    {
        if (scene.name == "MainScene")
        {
            if (DIR.powerButtonState == 0 && !end)
            {
                //FadeCameraout, at end of fade, end the scene;
                CFS.FadeCanvasOut(fadeLength);
                end = true;
                start = false;
                StartCoroutine("FadeOutSceneMasterVol");
            }

            if(DIR.powerButtonState==1 && !start)
            {
                CFS.FadeCanvasIn(fadeLength);
                end = false;
                start = true;
                StartCoroutine("FadeInSceneMasterVol");
            }
        }
        else if(scene.name=="WaitingScene")
        {
            if (DIR.powerButtonState == 1 && !end)
            {
                //FadeCameraout, at end of fade, end the scene;
                CFS.FadeCanvasOut(fadeLength);

                end = true;
                start = false;
            }

            if (DIR.powerButtonState == 0 && !start)
            {
                CFS.FadeCanvasIn(fadeLength);
                end = false;
                start = true;
            }
        }
    }
    IEnumerator FadeOutSceneMasterVol()
    {
        float _fadeLength= fadeLength;
        float masterVol = DO.masterVol;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / Time.timeScale / _fadeLength)
        {
            DO.masterVol= Mathf.Lerp(masterVol, -80, t);

            yield return null;
        }
        Debug.LogWarning("SoundFadedout");
    }
    IEnumerator FadeInSceneMasterVol()
    {
        float _fadeLength = fadeLength;
        float masterVol = DO.masterVol;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / Time.timeScale / _fadeLength)
        {
            DO.masterVol = Mathf.Lerp(masterVol, -12, t);

            yield return null;
        }
        Debug.LogWarning("SoundFadedin");
    }
}
