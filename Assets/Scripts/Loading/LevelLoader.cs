using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)levelToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
