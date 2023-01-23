using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public GameObject flashlightObject;
    public bool isUnlocked = false;

    void Start()
    {
        flashlight.enabled = false;
        flashlightObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isUnlocked)
                return;

            flashlight.enabled = !flashlight.enabled;
            flashlightObject.SetActive(flashlight.enabled);
        }
    }

    public void Unlock()
    {
        isUnlocked = true;
    }

}
