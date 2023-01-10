using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent OnTrigger;
    [SerializeField] bool isActive=true;
    [SerializeField] UnityEvent onActivate;
    [SerializeField] UnityEvent onDeactivate;
    public void Trigger()
    {
        if(!isActive)
        return;
        OnTrigger.Invoke();
    }
    public void Active(){
        isActive = true;
        onActivate.Invoke();
    }
    public void Deactivate(){
        isActive = false;
        onDeactivate.Invoke();
    }
}
