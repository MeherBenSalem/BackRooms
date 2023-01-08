using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    [SerializeField] VideoPlayer screen;
    [SerializeField] Light tvLight;
    [SerializeField] VideoClip nextVideo;

    void Start()
    {
        screen.isLooping = true;
        tvLight.enabled = false;
        screen.loopPointReached += ChangeVideo;
    }

    public void ToggleVideo()
    {
        if (screen.isPlaying)
        {
            screen.Stop();
            tvLight.enabled = false;
        }
        else
        {
            screen.Play();
            tvLight.enabled = true;
        }
    }

    void ChangeVideo(VideoPlayer vp)
    {
        screen.clip = nextVideo;
        screen.Play();
    }
}
