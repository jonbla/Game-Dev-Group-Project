using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string name;
    [Range(0, 100)]
    public int health;

    TextMeshPro nameText;

    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponentInChildren<TextMeshPro>();

        nameText.text = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
