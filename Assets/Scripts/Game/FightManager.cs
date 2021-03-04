using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour, ExtraStructs
{
    [Serializable]
    public struct enemyGraphic
    {
        public Sprite image;
        public string name;
    }

    public static bool playerTurn;
    public static bool newFight;
    
    public GameObject enemy;
    private GameObject clone;    

    [Space]
    public enemyGraphic[] enemySprites;

    Background background;

    private static bool lockTurn;
    void Start()
    {
        playerTurn = true;
        newFight = true;
        lockTurn = false;

        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();
    }

    // Update is called once per frame
    void Update()
    {
        if (newFight)
            InitFight();
        if (!lockTurn)
            HandleTurn();
    }

    void InitFight()
    {
        newFight = false;
        print("I made an enemy!");

        clone = Instantiate(enemy, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        print(enemySprites[EnemyNameSetter.GetEnemyInfo(background.enemyLevel).graphic].name);

        EnemyInfo info = EnemyNameSetter.GetEnemyInfo(background.enemyLevel);

        clone.GetComponent<Enemy>().enemyName = enemySprites[info.graphic].name;
        clone.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = enemySprites[info.graphic].image;

    }

    void HandleTurn()
    {
        lockTurn = true;
        if (!playerTurn)
        {
            clone.GetComponent<Enemy>().DoTurn();
            playerTurn = true;
        }
        lockTurn = false;
    }
}
