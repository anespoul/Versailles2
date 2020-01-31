using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(PlayVideo());    
    }

    IEnumerator PlayVideo() 
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(Time.deltaTime);

        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        // audioSource.Play();
    }
}
