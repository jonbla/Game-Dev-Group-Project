using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class LoadManager
{

    static void LoadLevel(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }
}
