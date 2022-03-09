using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFadeAuxFunctions : MonoBehaviour
{
    public GameObject videoParent;
    // Start is called before the first frame update
    void Start()
    {
        videoParent = GameObject.Find("VideoParent");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBottleVideo()
    {
        videoParent.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void PlayMaryVideo()
    {
        
        videoParent.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void PlayMaryVideo2()
    {

        videoParent.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void PlayMaryVideo3()
    {

        videoParent.transform.GetChild(3).gameObject.SetActive(true);
    }
    public void RemoveVideos()
    {
        videoParent.transform.GetChild(0).gameObject.SetActive(false);
        videoParent.transform.GetChild(1).gameObject.SetActive(false);
        videoParent.transform.GetChild(2).gameObject.SetActive(false);
        videoParent.transform.GetChild(3).gameObject.SetActive(false);
    }
}
