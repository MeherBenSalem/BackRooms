using UnityEngine;
using UnityEditor;

public class Door : MonoBehaviour
{
private bool isOpen = false;
[SerializeField] private bool isLocked = false;
private Animator animator;

void Start()
{
    animator = GetComponent<Animator>();
}

public void ToggleDoor()
{
    if(isLocked){
    Debug.Log("Door Locked");
    return;}

    if (!isOpen)
    {
        animator.SetTrigger("Open");
        isOpen = true;
    }
    else
    {
        animator.SetTrigger("Close");
        isOpen = false;
    }
}

public void Lock()
{
    isLocked = true;
}
public void Unlock()
{
    isLocked = false;
}

}