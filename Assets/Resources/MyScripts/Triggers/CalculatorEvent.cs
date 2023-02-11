using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CalculatorEvent : MonoBehaviour
{
[SerializeField] Lever[] levers;
[SerializeField] UnityEvent onReach;

public void Check(){
    foreach (Lever lever in levers) {
    if (!lever.isOn) {
      return;
    }
  }
  onReach.Invoke();
}
}
