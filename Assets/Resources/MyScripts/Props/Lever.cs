using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public bool isOn = false;
    public UnityEvent OnEvent;
    public UnityEvent OffEvent;
    public Light lightOn;
    public Animator anim;

    void Start(){
        Activate();
    }

    public void Activate()
    {
        isOn = !isOn;
        if (isOn)
        {
        OnEvent.Invoke();
        anim.Play("Lever_On");
        lightOn.enabled=true;
        }
        else
        {
        OffEvent.Invoke();
        anim.Play("Lever_Off");
        lightOn.enabled=false;
        }
    }
}
