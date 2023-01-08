using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent OnTrigger;
    // Start is called before the first frame update
    public void Trigger()
    {
        Debug.Log("Triggered");
        OnTrigger.Invoke();
    }
}
