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

    [Range(0, 100)]
    public int health;

    TextMeshPro nameText;

    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponentInChildren<TextMeshPro>();

        nameText.text = enemyName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoTurn()
    {
        print("Enemy turn");
    }
}
