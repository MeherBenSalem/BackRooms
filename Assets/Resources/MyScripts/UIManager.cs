using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionMenu;
    [SerializeField] GameObject letterMenu;
    [SerializeField] Text panelText;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
        }
    }

    public void OpenPauseMenu()
    {
        MyPlayerController.instance.canMove=false;
        pauseMenu.SetActive(true);
        Time.timeScale=0f;
        isPaused = true;        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ClosePauseMenu()
    {
        MyPlayerController.instance.canMove=true;
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
        Time.timeScale=1f;
        isPaused = false;        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ShowPanel(string text)
    {
        letterMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MyPlayerController.instance.canMove=false;
        panelText.text = text;
    }

    public void ClosePanel(){        
        MyPlayerController.instance.canMove=true;
        letterMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
