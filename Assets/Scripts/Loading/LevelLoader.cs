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
    /// Enum to easily name scene indexes
    /// </summary>
    public enum level
    {
        LOADING,
        MAIN_MENU,
        GAME_SCENE
    };

    /// <summary>
    /// Target scene to load
    /// </summary>
    public level levelToLoad;

    /// <summary>
    /// called during first frame
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Load the Desired Scene
    /// </summary>
    public void Load()
    {
        StartCoroutine(LoadAsynchronously((int)levelToLoad));
    }

    public void Load(int lvlIndex)
    {
        StartCoroutine(LoadAsynchronously(lvlIndex));
    }

    /// <summary>
    /// Play Transition Animation
    /// </summary>
    void Animate()
    {
        DOTween.PlayAll();
    }

    /// <summary>
    /// Unloads Current Scene
    /// </summary>
    public void KillScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

    /// <summary>
    /// Coroutine to Load New level
    /// </summary>
    /// <param name="levelIndex">Terget Level To Load</param>
    /// <returns></returns>
    IEnumerator LoadAsynchronously(int levelIndex) {
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)levelToLoad, LoadSceneMode.Additive);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //In Unity, the progress bar goes to 90%, the last 10% is a different operation, so we won't include it

            Debug.Log("Load Progress: "+progress);
            yield return null;
        }
        Animate();
    }
}
