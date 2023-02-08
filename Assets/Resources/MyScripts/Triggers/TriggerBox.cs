using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBox : MonoBehaviour
{
    public UnityEvent triggerEvent;

    [SerializeField] bool isOnce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            Debug.Log("Triuiger");
            triggerEvent.Invoke();
            if(isOnce){
                Destroy(this.gameObject);
            }
        }
    }
}
