<<<<<<< Updated upstream:Assets/Scripts/Game/FightManager.cs
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
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

        //Instantiate enemy and keep reference to it 
        clone = Instantiate(enemy, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        //Give enemy an identity
        //background.EnemyLevelUp();
        //background.EnemyLevelUp();
        //background.EnemyLevelUp();
        //background.EnemyLevelUp();
        SetEnemyInfo(clone, background.enemyTier);

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

    void SetEnemyInfo(GameObject enemy, int tier)
    {
        //Get info about spawned enemy based on tier
        EnemyInfo info = EnemyNameSetter.GetEnemyInfo(tier);

        //Set name
        enemy.GetComponent<Enemy>().enemyName = enemySprites[info.graphic].name;

        //Set image
        enemy.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = enemySprites[info.graphic].image;
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static bool playerTurn;
    public static bool newFight;
    
    public GameObject enemy;
    private GameObject clone;


    private static bool lockTurn;
    void Start()
    {
        playerTurn = true;
        newFight = true;
        lockTurn = false;
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
>>>>>>> Stashed changes:Assets/Scripts/Other/Static/FightManager.cs
