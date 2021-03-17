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
    private GameObject playerButtons;

    PlayerStats player;
    LevelLoader levelLoader_Upgrade;
    LevelLoader levelLoader_EndScreen;

    bool alreadyOn = false;
    [Space]
    public enemyGraphic[] enemySprites;

    Background background;

    void Start()
    {
        playerTurn = true;
        isFightActive = true;

        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();
        player = GameObject.Find("Code").transform.Find("Player Stats").GetComponent<PlayerStats>();
        playerButtons = GameObject.FindGameObjectWithTag("PLAYER BUTTONS");
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
            levelLoader_Upgrade.BasicLoad();
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

       IEnumerator turnWaiter(){
        if (!alreadyOn){
            alreadyOn = true;
            playerButtons.SetActive(false);
            yield return new WaitForSeconds(2);
            enemy.DoTurn();
            yield return new WaitForSeconds(1);
            ToggleTurn();
            alreadyOn = false;
            playerButtons.SetActive(true);
        }

    }
    void HandleTurn()
    {
        if (!playerTurn)
        {
            StartCoroutine("turnWaiter");
        }
    }

    void SetEnemyInfo(GameObject enemyTemp, int tier)
    {
        //Get info about spawned enemy based on tier
        EnemyInfo info = EnemyNameSetter.GetEnemyInfo(tier);

        //Set name
        enemyTemp.GetComponent<Enemy>().enemyName = enemySprites[info.graphic].name;
        enemy.tier = tier;
        //Set image
        enemyTemp.transform.Find("Vertical Container").transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = enemySprites[info.graphic].image;
        print("I AM THIS TIER: " +enemy.tier);
        switch (enemy.tier)
        {
            case 0: 
                enemy.maxHealth = RollDice(4, 10) + 10;
                enemy.T1Music.enabled = true;
                break;
            case 1: 
                enemy.maxHealth = RollDice(4, 10) + 10;
                enemy.T1Music.enabled = true;
                break;
            case 2:
                enemy.maxHealth = RollDice(6, 10) + 20;
                enemy.T2Music.enabled = true;
                break;
            case 3:
                enemy.maxHealth = RollDice(8, 10) + 25;
                enemy.T3Music.enabled = true;
                break;
            case 4:
                enemy.maxHealth = RollDice(10, 10) + 30;
                enemy.T4Music.enabled = true;
                break;
            case 5:
                enemy.maxHealth = 150;
                enemy.T4Music.enabled = true;
                break;
            default:
                enemy.maxHealth = 150;
                break;
        }
        enemy.maxMana = 100; //Dont know what to set it to.
        enemy.health = enemy.maxHealth;
        enemy.mana = enemy.maxMana /2 ;
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
