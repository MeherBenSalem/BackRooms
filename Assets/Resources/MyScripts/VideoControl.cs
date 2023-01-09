using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    [SerializeField] VideoPlayer screen;
    [SerializeField] Light tvLight;
    [SerializeField] UnityEvent OnVideoFinish,OnVideoPlay,OnVideoStop;
    [SerializeField] bool canBeClosed;


    void Start()
    {
        screen.isLooping = true;
        tvLight.enabled = false;
        screen.loopPointReached += ChangeVideo;
    }

    public void ToggleVideo()
    {
        if (screen.isPlaying&&canBeClosed)
        {
            OnVideoStop.Invoke();
            screen.Stop();
            tvLight.enabled = false;
        }
        else
        {
            OnVideoPlay.Invoke();
            screen.Play();
            tvLight.enabled = true;
        }
    }

    public void closeVideo(){
        OnVideoStop.Invoke();
        screen.Stop();
        tvLight.enabled = false;
    }

    void ChangeVideo(VideoPlayer vp)
    {
        OnVideoFinish.Invoke();
    }

    public void PlayVideo(VideoClip vc){
        screen.clip = vc;
        ToggleVideo();
    }
}
