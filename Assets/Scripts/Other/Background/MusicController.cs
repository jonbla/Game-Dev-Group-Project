using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource[] sources;

    public AudioSource T1Music   { get => sources[0]; }
    public AudioSource T2Music   { get => sources[1]; }
    public AudioSource T3Music   { get => sources[2]; }
    public AudioSource T4Music   { get => sources[3]; }
    public AudioSource MenuMusic { get => sources[4]; }
    public AudioSource UpgradeMusic { get => sources[5]; }

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Music");
        if (gameObjects.Length >= 2)
        {
            Destroy(gameObjects[gameObjects.Length - 1].gameObject);
        }

        MenuMusic.Play();
        DontDestroyOnLoad(this.gameObject);
    }


    public void StopAll()
    {
        T1Music.Stop();
        T2Music.Stop();
        T3Music.Stop();
        T4Music.Stop();
        MenuMusic.Stop();
        UpgradeMusic.Stop();
    }
}
