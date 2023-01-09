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
    // Start is called before the first frame update
    public void Trigger()
    {
        if(!isActive)
        return;
        Debug.Log("Trigger");
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
