using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    public string correctCode = "1234";
    private string inputCode = "";
    public UnityEvent onCodeEntered;
    public AudioClip buttonSound;
    public AudioClip successSound;
    public AudioClip failSound;
    AudioSource player;

    void Start(){
        player = GetComponent<AudioSource>();
    }

    public void EnterCode(string code)
    {
        PlayAudio(buttonSound);
        inputCode += code;
        if(inputCode.Length < 4)
            return;
        if (inputCode == correctCode)
        {       
            PlayAudio(successSound);
            onCodeEntered.Invoke();
            inputCode = "";
        }
        else
        {
            PlayAudio(failSound);
            inputCode = "";
        }
    }

    public void PlayAudio(AudioClip clip){
        player.clip = clip;
        player.Play();
    }
}
