using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
public bool isOn = false;
public UnityEvent OnEvent;
public UnityEvent OffEvent;
public Light lightOn;
public Animator anim;
public Lever[] otherLeversToActivate;

void Start(){
  Activate();
}

public void Activate()
{
  if (isOn)
  {
    OffEvent.Invoke();
    anim.Play("Lever_Off");
    lightOn.enabled=false;
    if(otherLeversToActivate.Length>1)
    foreach (Lever lever in otherLeversToActivate)
    {
      lever.isOn = false;
      lever.Activate();
    }
  }
  else
  {
    OnEvent.Invoke();
    anim.Play("Lever_On");
    lightOn.enabled=true;
    if(otherLeversToActivate.Length>1)
    foreach (Lever lever in otherLeversToActivate)
    {
      lever.isOn = true;
      lever.Activate();
    }
  }
  isOn = !isOn;
}

}
