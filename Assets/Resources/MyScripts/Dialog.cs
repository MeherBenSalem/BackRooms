using System;
using UnityEngine;
public class Dialog : MonoBehaviour
{
    public AudioSource audioSource;
    public string[] texts;
    public float changeInterval;
    public bool isOnce;
    public void PlayerDialog(){
        DialogControl.instance.StartAudio(this);
    }

}
