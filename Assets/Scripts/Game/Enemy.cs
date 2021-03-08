using TMPro;
using UnityEngine;

/// <summary>
/// Controller for Enemy prefab
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// Name of spawned enemy
    /// </summary>
    public string enemyName;

    //[Range(0, 100)]
    float health = 100f;

    TextMeshPro nameText;
    PlayerStats player;


    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponentInChildren<TextMeshPro>();
        player = GameObject.Find("Code").transform.Find("Player Stats").GetComponent<PlayerStats>();

        nameText.text = enemyName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoTurn()
    {
        print("Enemy turn");
        player.TakeDamage(10); //placeholder code
    }

    public void TakeDamage(int val)
    {
        health -= val;
    }

    public float GetCurrentHP()
    {
        return health;
    }
}
