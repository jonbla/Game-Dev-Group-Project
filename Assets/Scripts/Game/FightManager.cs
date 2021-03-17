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

    bool playerTurn;
    bool isFightActive;
    
    public GameObject enemyPrefab;
    private Enemy enemy;
    private GameObject clone;

    PlayerStats player;
    LevelLoader levelLoader_Upgrade;
    LevelLoader levelLoader_EndScreen;

    [Space]
    public enemyGraphic[] enemySprites;

    Background background;

    void Start()
    {
        playerTurn = true;
        isFightActive = true;

        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();
        player = GameObject.Find("Code").transform.Find("Player Stats").GetComponent<PlayerStats>();
        levelLoader_Upgrade = GameObject.Find("Code").transform.Find("Upgrade Load Manager").GetComponent<LevelLoader>();
        levelLoader_EndScreen = GameObject.Find("Code").transform.Find("Enter Screen Load Manager").GetComponent<LevelLoader>();
        InitFight();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetCurrentHP() <= 0f)
        {
            print("Enemy: "+enemy.GetCurrentHP());
            print("Player: " + player.GetCurrentHP());

            isFightActive = false;

            if(enemy.tier >= 4)
            {
                levelLoader_EndScreen.BasicLoad();
            }
            else
            {
                levelLoader_Upgrade.BasicLoad();
            }            
        }

        if(player.GetCurrentHP() <= 0f)
        {
            print("Enemy: " + enemy.GetCurrentHP());
            print("Player: " + player.GetCurrentHP());

            isFightActive = false;
            background.playerLost = true;
            levelLoader_EndScreen.BasicLoad();
        }

        HandleTurn();
    }

    void InitFight()
    {
        print("I made an enemy!");

        //Instantiate enemy and keep reference to it 
        clone = Instantiate(enemyPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        enemy = clone.GetComponent<Enemy>();

        //Give enemy an identity
        SetEnemyInfo(clone, background.enemyTier);

    }

    public void ToggleTurn()
    {
        playerTurn = !playerTurn;
    }

    public bool getIsPlayerTurn()
    {
        return playerTurn;
    }

    void HandleTurn()
    {
        if (!playerTurn)
        {
            enemy.DoTurn();
            ToggleTurn();
        }
    }

    void SetEnemyInfo(GameObject enemyTemp, int tier)
    {
        //Get info about spawned enemy based on tier
        EnemyInfo info = EnemyNameSetter.GetEnemyInfo(tier);

        //Set name
        enemyTemp.GetComponent<Enemy>().enemyName = enemySprites[info.graphic].name;

        //Set tier
        enemyTemp.GetComponent<Enemy>().tier = tier;

        //Set image
        enemyTemp.transform.Find("Vertical Container").transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = enemySprites[info.graphic].image;
        
        switch (enemy.tier)
        {
            case 1: 
                enemy.maxHealth = RollDice(4, 10) + 10;
                break;
            case 2:
                enemy.maxHealth = RollDice(6, 10) + 20;
                break;
            case 3:
                enemy.maxHealth = RollDice(8, 10) + 25;
                break;
            case 4:
                enemy.maxHealth = RollDice(10, 10) + 30;
                break;
            default:
                enemy.maxHealth = 150;
                break;
        }
        enemy.maxMana = 20; //Dont know what to set it to.
        enemy.health = enemy.maxHealth;
        enemy.mana = enemy.maxMana;
    }

    public void Flee()
    {
        isFightActive = false;
        background.playerLost = true;
        levelLoader_EndScreen.BasicLoad();
    }
    private int RollDice(int numOfDie, int dieSides)
    {
        // ie, RollDice(2,6) would roll two 6 sided dice
        int totalRolled = 0;
        for (int i = 0; i < numOfDie; i++)
        {
            totalRolled += UnityEngine.Random.Range(1, dieSides + 1);
        }

        return totalRolled;
    }
}
