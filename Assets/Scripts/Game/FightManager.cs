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
    LevelLoader levelLoader;

    [Space]
    public enemyGraphic[] enemySprites;

    Background background;

    void Start()
    {
        playerTurn = true;
        isFightActive = true;

        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();
        player = GameObject.Find("Code").transform.Find("Player Stats").GetComponent<PlayerStats>();
        levelLoader = GameObject.Find("Code").transform.Find("Load Manager").GetComponent<LevelLoader>();
        InitFight();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetCurrentHP() <= 0f || player.GetCurrentHP() <= 0f)
        {
            print("Enemy: "+enemy.GetCurrentHP());
            print("Player: " + player.GetCurrentHP());

            isFightActive = false;
            levelLoader.BasicLoad();
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

        //Set image
        enemyTemp.transform.Find("Vertical Container").transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = enemySprites[info.graphic].image;
    }
}
