using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image m_Image;
  

    void Start()
    {
        m_Image = GetComponent<Image>();
    }

    //IEnumerator FadeTo(float aValue, float aTime)
    //{
    //    float alpha = GetComponent<Image>().color.a;

    //    for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
    //    {
    //        Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
    //        GetComponent<Image>().color = newColor;
    //        yield return null;
    //    }
    //}

    public void FadeOutIcon()
    {
        CancelInvoke();
        m_Image.CrossFadeAlpha(0, 0.5f, true);
        Invoke("FadeInIcon",2);
        //StartCoroutine(FadeTo(0.0f, 1.5f));
        //  gameObject.transform.GetComponentInParent<BoxCollider>().enabled = false;

    }
    
    public void FadeInIcon()
    {
        m_Image.CrossFadeAlpha(1, 2.0f, true);
        //StartCoroutine(FadeTo(1.0f, 1.5f));
        //   gameObject.transform.GetComponentInParent<BoxCollider>().enabled = true;
    }
}