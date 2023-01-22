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
        // Start a load operation for the new scene
        loadOperation = SceneManager.LoadSceneAsync(index);

        // Wait for the load operation to complete
        while (!loadOperation.isDone)
        {
            float progress = Mathf.Clamp01(loadOperation.progress / 0.9f);
            progressSlider.value = progress;
            yield return null;
        }
    }
}
