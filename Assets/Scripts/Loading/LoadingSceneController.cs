using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneController : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Load Manager").GetComponent<LevelLoader>().AnimatedLoad();
    }
}
