using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        // If there is no instance of the game manager, set this object to be the instance
        if (instance == null)
        {
            instance = this;
        }
        // If there is already an instance of the game manager, destroy this object
        else
        {
            Destroy(gameObject);
        }

        // Don't destroy the game manager when a new scene is loaded
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
