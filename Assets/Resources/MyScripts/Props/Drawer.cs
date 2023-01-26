using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    Animator drawerAnimator;
    public bool isOpen = false;

    void Start(){
        drawerAnimator = GetComponent<Animator>();
    }

    public void OpenCloseDrawer()
    {
        if (isOpen)
        {
            drawerAnimator.Play("Drawer_Open");
            isOpen = false;
        }
        else
        {
            drawerAnimator.Play("Drawer_Close");
            isOpen = true;
        }
    }
}
