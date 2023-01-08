using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    [SerializeField] bool isAudioOn;
    [SerializeField] bool isOnce;
    public AudioSource audioSource;
    public Text text;
    public string[] texts;
    public float changeInterval = 5.0f; // Interval in seconds at which to change the text

    bool isPlaying;

    public void StartAudio()
    {
        if(text.isActiveAndEnabled)
        return;
        text.enabled = true;
        text.text = texts[0];
        if(isAudioOn)
        audioSource.Play();
        isPlaying = true;
        StartCoroutine(UpdateText());
    }

    IEnumerator UpdateText()
    {
    while(isPlaying)
    {
        yield return new WaitForSeconds(changeInterval);
        int nextIndex = (Array.IndexOf(texts, text.text) + 1) % texts.Length;
        if (nextIndex == 0) {
            text.enabled = false;
            isPlaying = false;
            if (isOnce) {
                Destroy(this.gameObject,1f);
            }
            yield break;
        }
        text.text = texts[nextIndex];
    }
    }
}
