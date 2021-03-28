using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    /// <summary>
    /// Image and graphic of enemy
    /// </summary>
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
    LevelLoader levelLoader_Reload;

    bool alreadyOn = false;
    bool loading = false;

    /// <summary>
    /// List of Graphics and names
    /// </summary>
    [Space]    
    public enemyGraphic[] enemySprites;

    Background background;
    MusicController musicController;

    void Start()
    {
        playerTurn = true;
        isFightActive = true;

        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();
        musicController = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>();
        player = GameObject.Find("Code").transform.Find("Player Stats").GetComponent<PlayerStats>();

        levelLoader_Upgrade = GameObject.Find("Code").transform.Find("Upgrade Load Manager").GetComponent<LevelLoader>();
        levelLoader_EndScreen = GameObject.Find("Code").transform.Find("End Screen Load Manager").GetComponent<LevelLoader>();
        levelLoader_Reload = GameObject.Find("Code").transform.Find("Reload Load Manager").GetComponent<LevelLoader>();

        playerButtons = GameObject.FindGameObjectWithTag("PLAYER BUTTONS");

        InitFight();
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        //Prevents boss from spawning twice
        if (enemy.tier >= 4)
        {
            background.tierRematch = true;
        }

        if (!isFightActive)             //if fight is done
        {
            if (enemy.isDead)           //wait until enemy animation is done
            {
                if (player.readyToKill) //then wait until player healthbar animation is done
                {
                    DoSceneChange();
                }
                player.DoInfoBarAnimation();
            }
            return;
        }        

        if (enemy.GetCurrentHP() <= 0f)
        {
            print("Enemy: " + enemy.GetCurrentHP());
            print("Player: " + player.GetCurrentHP());

            isFightActive = false;
            enemy.Die();
            return;
        }

        if (player.GetCurrentHP() <= 0f)
        {
            print("Enemy: " + enemy.GetCurrentHP());
            print("Player: " + player.GetCurrentHP());

            isFightActive = false;
            background.playerLost = true;
            levelLoader_EndScreen.BasicLoad();
        }

        HandleTurn();
    }

    private void DoSceneChange()
    {
        if (background.tierRematch)
        {
            background.tierRematch = false;
            if (enemy.tier >= 4)
            {
                loading = true;
                levelLoader_EndScreen.BasicLoad();
            }
            else
            {
                loading = true;
                levelLoader_Upgrade.BasicLoad();
            }
        }
        else
        {
            if (!loading)
            {
                background.tierRematch = true;
                levelLoader_Reload.ReloadCurrentScene();
            }
        }
    }

    /// <summary>
    /// Instantiates a fight
    /// </summary>
    void InitFight()
    {
        print("I made an enemy!");

        //Instantiate enemy and keep reference to it 
        clone = Instantiate(enemyPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        enemy = clone.GetComponent<Enemy>();

        //Give enemy an identity
        SetEnemyInfo(clone, background.enemyTier);

    }

    /// <summary>
    /// Change who gets to attack
    /// </summary>
    public void ToggleTurn()
    {
        playerTurn = !playerTurn;
    }

    /// <summary>
    /// Reports on who's turn it is
    /// </summary>
    /// <returns>Player turn</returns>
    public bool getIsPlayerTurn()
    {
        return playerTurn;
    }

    /// <summary>
    /// Simulates enemy thinking to attack
    /// </summary>
    IEnumerator turnWaiter()
    {
        if (!alreadyOn){
            alreadyOn = true;
            playerButtons.SetActive(false);
            yield return new WaitForSeconds(1);
            if (isFightActive)
            {
                enemy.DoTurn();
                yield return new WaitForSeconds(.5f);
                ToggleTurn();
                alreadyOn = false;
                playerButtons.SetActive(true);
            }
            else
            {
                playerButtons.SetActive(false);
            }            
        }

    }

    /// <summary>
    /// Applies turn params on turn switch
    /// </summary>
    void HandleTurn()
    {
        if (!playerTurn)
        {
            StartCoroutine("turnWaiter");
        }
    }

    /// <summary>
    /// Populate variable in spawned enemy prefab
    /// </summary>
    /// <param name="enemyTemp"> Enemy prefab to populate</param>
    /// <param name="tier">The target tier for enemy</param>
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
                enemy.maxHealth = Dice.RollDice(4, 10 + 1) + 10;
                musicController.StopAll();
                musicController.T1Music.Play();
                break;
            case 1: 
                enemy.maxHealth = Dice.RollDice(4, 10 + 1) + 10;
                musicController.StopAll();
                musicController.T1Music.Play();
                break;
            case 2:
                enemy.maxHealth = Dice.RollDice(6, 10 + 1) + 20;
                musicController.StopAll();
                musicController.T2Music.Play();
                break;
            case 3:
                enemy.maxHealth = Dice.RollDice(8, 10 + 1) + 25;
                musicController.StopAll();
                musicController.T3Music.Play();
                break;
            case 4:
                enemy.maxHealth = Dice.RollDice(10, 10 + 1) + 30;
                musicController.StopAll();
                musicController.T4Music.Play();
                break;
            case 5:
                enemy.maxHealth = 150;
                musicController.StopAll();
                musicController.T4Music.Play();
                break;
            default:
                enemy.maxHealth = 150;
                break;
        }
        enemy.maxMana = 100; //Dont know what to set it to.
        enemy.health = enemy.maxHealth;
        enemy.mana = enemy.maxMana /2 ;
    }

    /// <summary>
    /// Quits fight
    /// </summary>
    public void Flee()
    {
        isFightActive = false;
        background.playerLost = true;
        levelLoader_EndScreen.BasicLoad();
    }
}
