using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMemo : MonoBehaviour {
    public Animator panelFadeAnim;
    public GameObject panelExamMemo;
    public GameObject imageToShow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showImage()
    {
        Invoke("ShowImageCall", 1.5f);

        panelFadeAnim.Play("FadeIn");


    }

    public void ShowImageCall()
    {
        imageToShow.SetActive(true);
        panelExamMemo.SetActive(true);
      
    }
    public void Goodbye()
    {
        panelFadeAnim.Play("FadeOut");
        panelExamMemo.SetActive(false);
        imageToShow.SetActive(false);
        

    }
}
