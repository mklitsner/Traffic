using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFadeScript : MonoBehaviour
{
    public GameObject Panel;
 
    public void FadeCanvasOut(float _fadeLength){
        Debug.LogWarning("begin Fade out");
        StartCoroutine(FadeTo(1.0f, _fadeLength));
    }
    public void FadeCanvasIn(float _fadeLength)
    {
        Debug.LogWarning("begin Fade In");
        StartCoroutine(FadeTo(0.0f, _fadeLength));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = Panel.GetComponent<Image>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime/Time.timeScale/ aTime)
        {
            Panel.GetComponent<Image>().color = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));

            yield return null;
        }
        Debug.LogWarning("FadeOver");
    }
}
