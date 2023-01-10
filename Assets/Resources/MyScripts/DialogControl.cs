using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    public Text text;
    bool isPlaying;
    public Dialog currentDiag;
    public static DialogControl instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void StartAudio(Dialog dialog)
    {
        if(text.isActiveAndEnabled)
            return;
        StopAudio();
        currentDiag = dialog;
        if(currentDiag.audioSource!=null)
            currentDiag.audioSource.Play();
        text.enabled = true;
        text.text = currentDiag.texts[0];
        isPlaying = true;
        StartCoroutine(UpdateText());
    }

    IEnumerator UpdateText()
    {
    while(isPlaying)
    {
        yield return new WaitForSeconds(currentDiag.changeInterval);
        int nextIndex = (Array.IndexOf(currentDiag.texts, text.text) + 1) % currentDiag.texts.Length;
        if (nextIndex == 0) {
            text.enabled = false;
            isPlaying = false;
            if (currentDiag.isOnce) {
                Destroy(currentDiag.gameObject,1f);
            }
            yield break;
        }
        text.text = currentDiag.texts[nextIndex];
    }
    }
    public void StopAudio(){
        StopAllCoroutines();
        text.enabled = false;
    }
}
