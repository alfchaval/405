using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoFix : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public bool playOnAwake;

    void Start()
    {
        rawImage = gameObject.GetComponent<RawImage>();
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        audioSource = gameObject.GetComponent<AudioSource>();
        if (playOnAwake)
        {
            StartCoroutine(PlayVideo());
        }

    }

    IEnumerator PlayVideo()
    {
        videoPlayer.gameObject.GetComponent<VideoPlayer>().enabled = true;
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        
        videoPlayer.Play();
        audioSource.Play();
    }

    public void CallPlayVideo()
    {
        StartCoroutine(PlayVideo());
    } 
}