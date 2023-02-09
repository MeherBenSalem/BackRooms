using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSetter : MonoBehaviour
{
    Animator an;
    [SerializeField] string idleAnimString;
    void Start(){
        an = GetComponent<Animator>();
        an.Play(idleAnimString);
    }
    
}
