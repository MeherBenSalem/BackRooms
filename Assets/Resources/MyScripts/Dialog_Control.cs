using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_Control : MonoBehaviour
{
    Text textToUpdate;
    Animator an;

    void Start(){
        textToUpdate = GetComponent<Text>();
        an = GetComponent<Animator>();
    }

    public void Update_Text(string p){
        textToUpdate.text = p;
    }

    public void StartLine(float duration)
    {
        an.enabled = false;
        textToUpdate.enabled = true;
        Invoke("HideText", duration);
    }

    private void HideText()
    {
        an.enabled = true;
    }
}
