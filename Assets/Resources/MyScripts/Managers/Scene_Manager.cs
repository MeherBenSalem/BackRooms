using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] Slider progressSlider;
    [SerializeField] GameObject toActivate;
    [SerializeField] Animator animator;
    AsyncOperation loadOperation;

    public void ChangeScene(int index)
    {
        toActivate.SetActive(true);
        animator.SetTrigger("Start");
        StartCoroutine(LoadSceneAsync(index));
    }

    IEnumerator LoadSceneAsync(int index)
    {
        float progress = 0;
        progressSlider.value = progress;
        yield return new WaitForSeconds(2);
        loadOperation = SceneManager.LoadSceneAsync(index);
        while (!loadOperation.isDone)
        {
            progress = Mathf.Clamp01(loadOperation.progress / 0.9f);
            progressSlider.value = progress;
            yield return null;
        }
    }
    public void Quit(){
        Application.Quit();
    }
}
