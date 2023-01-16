using UnityEngine;
using UnityEngine.UI;

public class LetterControl : MonoBehaviour
{
    public GameObject panel;
    public Text panelText;

    public void ShowPanel()
    {
        panel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MyPlayerController.instance.enabled=false;
    }

    public void SetPanelText(string text)
    {
        panelText.text = text;
    }
    public void ClosePanel(){        
        MyPlayerController.instance.enabled=true;
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
