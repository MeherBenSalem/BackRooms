using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerInteract : MonoBehaviour
{
    [SerializeField] LayerMask interactablesLayer;
    [SerializeField] float interactionRange=3f;
    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            fire();
        }
    }
    void fire(){
        // Get the screen center position
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        // Create a ray from the center of the screen in the direction of the camera
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        // Create a RaycastHit variable to store information about the hit
        RaycastHit hit;

        // Perform the raycast and if it hits something, store the information in the hit variable
        if (Physics.Raycast(ray, out hit,interactionRange,interactablesLayer))
        {
            hit.transform.GetComponent<Interactable>().Trigger();
        }
    }
}
