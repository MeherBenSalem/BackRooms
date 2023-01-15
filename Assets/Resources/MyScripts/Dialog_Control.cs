using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_Control : MonoBehaviour
{
    Text textToUpdate;

    void Start(){
        textToUpdate = GetComponent<Text>();
    }

    public void Update_Text(string p){
        textToUpdate.text = p;
    }
}
