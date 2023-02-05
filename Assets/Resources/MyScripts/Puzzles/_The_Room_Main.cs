using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class _The_Room_Main : MonoBehaviour
{
    [SerializeField] Interactable[] switches;
    [SerializeField] UnityEvent OnSuccess,OnFail,OnPuzzleStart;
    bool isStarted=false;

    public float timer = 60f;

    public void activatePuzzle(){
        if(isStarted)
        return;
        StartCoroutine(StartTimer());
        ActivateSwitches();
        OnPuzzleStart.Invoke();
        isStarted=true;
    }

    [SerializeField] float Damage;

    public void FailPuzzle(){
        MyPlayerVitals.instance.Health -= Damage;
        OnFail.Invoke();
        StopCoroutine(StartTimer());
    }
    public void SuccessPuzzle(){
        OnSuccess.Invoke();
        DisableSwitches();
        StopAllCoroutines();
    }
    void DisableSwitches(){
        foreach(Interactable s in switches){
            s.Deactivate();
        }
    }
    void ActivateSwitches(){
        foreach(Interactable s in switches){
            s.Active();
        }
    }
    IEnumerator StartTimer()
    {
        Debug.Log("Started");
        while (timer > 0f )
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }
        FailPuzzle();
    }
}
