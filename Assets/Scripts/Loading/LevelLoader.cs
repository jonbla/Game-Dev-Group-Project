using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    public enum level
    {
        LOADING,
        MAIN_MENU
    };


    public level levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynchronously((int)levelToLoad));
    }

    void Animate()
    {
        DOTween.PlayAll();
    }

    public void KillScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

    IEnumerator LoadAsynchronously(int levelIndex) {
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)levelToLoad, LoadSceneMode.Additive);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            Debug.Log(progress);
            yield return null;
        }
        Animate();
        //KillScene();
    }
}
