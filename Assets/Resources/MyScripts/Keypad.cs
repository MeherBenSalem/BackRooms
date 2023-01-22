using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    public string correctCode = "1234";
    private string inputCode = "";
    public UnityEvent onCodeEntered;
    public UnityEvent onWrongCodeEntered;

    public void EnterCode(string code)
    {
        inputCode += code;
        if (inputCode.Length > 4)
        {
            onWrongCodeEntered.Invoke();
            inputCode = "";
        }
        else if (inputCode == correctCode)
        {
            onCodeEntered.Invoke();
            inputCode = "";
        }
    }
}
