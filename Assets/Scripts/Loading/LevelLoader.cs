using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// Script Component to Smoothly Load New Levels
/// </summary>
public class LevelLoader : MonoBehaviour
{
    /// <summary>
    /// This check fixes a glitch where multiple instances of this script in different scenes are called at the same time
    /// </summary>
    bool hasBeenLoaded = false;

    /// <summary>
    /// Enum to easily name scene indexes
    /// </summary>
    public enum level
    {
        LOADING,
        MAIN_MENU,
        MAIN_MENU_NO_DELAY,
        GAME_SCENE,
        UPGRADES,
        END_SCREEN,
        INFO,        
    };

    /// <summary>
    /// Target scene to load
    /// </summary>
    public level levelToLoad;

    /// <summary>
    /// The Scene Script is at
    /// </summary>
    public level currentScene;

    /// <summary>
    /// Load the Desired Scene
    /// </summary>
    public void AnimatedLoad()
    {
        hasBeenLoaded = true;
        StartCoroutine(LoadAsynchronously((int)levelToLoad));
    }

    /// <summary>
    /// Load the Desired Scene
    /// </summary>
    /// <param name="lvlIndex">Level to load</param>
    public void AnimatedLoad(int lvlIndex)
    {
        hasBeenLoaded = true;
        StartCoroutine(LoadAsynchronously(lvlIndex));
    }

    /// <summary>
    /// Play Transition Animation
    /// </summary>
    void Animate()
    {
        if (!hasBeenLoaded) return;
        DOTween.PlayAll();
    }

    /// <summary>
    /// Unloads Current Scene
    /// </summary>
    public void KillScene()
    {
        if (!hasBeenLoaded) return;
        print("Set Active to: " + levelToLoad);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)currentScene));
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

    /// <summary>
    /// Coroutine to Load New level
    /// </summary>
    /// <param name="levelIndex">Terget Level To Load</param>
    /// <returns></returns>
    IEnumerator LoadAsynchronously(int levelIndex) {
        levelToLoad = (level)levelIndex;

        AsyncOperation operation = SceneManager.LoadSceneAsync((int)levelToLoad, LoadSceneMode.Additive);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //In Unity, the progress bar goes to 90%, the last 10% is a different operation, so we won't include it

            Debug.Log("Load Progress: "+progress);
            yield return null;
        }
        Animate();
    }

    IEnumerator LoadBasicAsynchronously(int levelIndex)
    {
        levelToLoad = (level)levelIndex;

        AsyncOperation operation = SceneManager.LoadSceneAsync((int)levelToLoad, LoadSceneMode.Single);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //In Unity, the progress bar goes to 90%, the last 10% is a different operation, so we won't include it

            Debug.Log("Load Progress: " + progress);
            yield return null;
        }
    }

    /// <summary>
    /// Do regular scene change
    /// </summary>
    /// <param name="lvl">Level to load</param>
    public void BasicLoad(int lvl)
    {
        StartCoroutine(LoadBasicAsynchronously((int)lvl));
    }

    /// <summary>
    /// Do regular scene change
    /// </summary>
    public void BasicLoad()
    {
        BasicLoad((int)levelToLoad);
    }

    public void ReloadCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
