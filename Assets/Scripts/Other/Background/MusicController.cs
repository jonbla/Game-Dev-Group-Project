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

    public AudioSource PunchSound { get => sources[6]; }
    public AudioSource EnemyMagicSound { get => sources[7]; }
    public AudioSource PlayerMagicSound { get => sources[8]; }
    public AudioSource EnemyPunchSound { get => sources[9]; }
    public AudioSource HealSound { get => sources[10]; }
    // Start is called before the first frame update
    void Start()
    {
        //Resolves duplication issue
        sources = GetComponents<AudioSource>();

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Music");
        if (gameObjects.Length >= 2)
        {
            Destroy(gameObjects[gameObjects.Length - 1].gameObject);
        }

        MenuMusic.Play();
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Stops all audio tracks
    /// </summary>
    public void StopAll()
    {
        //More scalable
        foreach(AudioSource source in sources)
        {
            source.Stop();
        }
    }
}
