using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CalculatorEvent : MonoBehaviour
{
    [SerializeField] int required;

    [SerializeField] UnityEvent onReach;
    int Current=0;

    public void Reduce(int amount){
        Current-=amount;
        Checked();
    }
    public void Add(int amount){
        Current+=amount;
        Checked();
    }    
    public void Checked(){
        if(required==Current){
            onReach.Invoke();
        }
    }
}
