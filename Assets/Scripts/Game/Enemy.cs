using System.ComponentModel;
using TMPro;
using UnityEditor;
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
    Background background;

    [Range(0, 160)]
    public int health;
    [Range(0, 160)]
    public int maxHealth;
    [Range(0, 100)]
    public int maxMana;
    [Range(0, 100)]
    public int mana;

    public int tier;
    public int damage = 5;

    public PlayerStats playerStats;

    TextMeshPro nameText;
    PlayerStats player;
    public StatBars healthBar;
    public StatBars magicBar;


    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponentInChildren<TextMeshPro>();
        player = GameObject.Find("Code").transform.Find("Player Stats").GetComponent<PlayerStats>();

        nameText.text = enemyName;
        GameObject tempPlayer;
        tempPlayer = GameObject.Find("Player Stats");
        playerStats = tempPlayer.GetComponent<PlayerStats>();
        healthBar = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<StatBars>();
        magicBar = GameObject.FindGameObjectWithTag("EnemyMana").GetComponent<StatBars>();
    }

    public void DoTurn()
    {
        int tmpdmg = 0;
        print("Enemy turn");

        switch (DecideAction()){
            case 0: //just deal damage normally
                //player.health -= damage;
                        playerStats.TakeDamage(damage);
                    ;break;

    // HEALING SPELLS #######################################################
            case 1: //we are going to heal t1
                mana -= 40;
                health += RollDice(2,12);
                    ;break;
            case 4: //we are going to heal t2
                mana -= 50;
                health += RollDice(3,12);
                    ;break;
            case 5: //we are going to heal t3
                mana -= 60;
                health += RollDice(4,12);
                    ;break;
            case 6: //we are going to heal t4
                mana -= 40;
                health += RollDice(5,12) + 15;
                    ;break;
    // OFFENSIVE SPELLS #######################################################
            case 2: // WhistleStrike
                mana -= 10;
                playerStats.TakeDamage(RollDice(2,4));
                playerStats.UseMagic(-10);
                    ;break;
            case 3: // FireBolt
                mana -= 20;
                playerStats.TakeDamage(RollDice(2,8));
                playerStats.UseMagic(-20);
                    ;break;

            case 7: // lightingBolt
                mana -= 50;
                playerStats.TakeDamage(RollDice(3,10));
                playerStats.UseMagic(-50);
                    ;break;
            case 8: // dark dagger - Bolt
                mana -= 30;
                playerStats.TakeDamage(RollDice(3,8));
                playerStats.UseMagic(-30);
                    ;break;
            case 9: // lightingBolt
                mana -= 60;
                playerStats.TakeDamage(RollDice(5,8));
                playerStats.UseMagic(-60);
                    ;break;
            case 10: // dark dagger - Bolt
                mana -= 40;
                tmpdmg = RollDice(3,8);
                playerStats.TakeDamage(tmpdmg);
                health += tmpdmg;
                playerStats.UseMagic(-40);
                    ;break;
            case 11: // lightingBolt
                mana -= 80;
                playerStats.TakeDamage(RollDice(5,12));
                playerStats.UseMagic(-80);
                    ;break;
            case 12: // dark dagger - Bolt
                mana -= 70;
                tmpdmg = RollDice(6,8);
                playerStats.TakeDamage(tmpdmg);
                health -= tmpdmg /4;
                playerStats.UseMagic(-70);
                    ;break;
            default:
                playerStats.TakeDamage(damage); 
                    ;break;
        }
        magicBar.SetMagic(mana, maxMana);
    }
    
    public int DecideAction(){
        // we have some mana, lets see if we can cast a spell
        if (mana > 0){
            if (health <= maxHealth/2){
                //try and cast heal spell
                if (tier>=4){
                    if (mana >= 80) {
                        return 6; //HEAL 4
                    }
                }
                if (tier>=3){
                    if (mana >= 60) {
                        return 5; //HEAL 3
                    }
                }
                if (tier>=2){
                    if (mana >= 50) {
                        return 4; //HEAL 2
                    }
                }
                if (tier>=1){
                    if (mana >= 40) {
                        return 1;
                    }
                }
            }
            // our health is good, lets try and cast a offensive spell (as potent as possible)
            if (tier>=3){
                if (mana >= 80){
                    return 12;          //DAMAGE 5
                } else if (mana >= 70){
                    return 11;          //DAMAGE 6
                    }
                }
            
            if (tier>=2){
                if (mana >= 60){
                    return 10;          //DAMAGE 3
                } else if (mana >= 40){
                    return 9;           //DAMAGE 4
                    }
                }
            
            if (tier>=1){
                if (mana >= 50){
                    return 8;           //DAMAGE 2
                } else if (mana >= 30){
                    return 7;           //DAMAGE 1
                    }
                }
            
            if (tier>=0){
                if (mana >= 30){
                    return 3;
                } else if (mana > 0){
                    return 2;
                    }
                }
            }
        // we don't want to cast a spell, use default damage
         return 0;
    }

    private int RollDice(int numOfDie, int dieSides)
    {
        // ie, RollDice(2,6) would roll two 6 sided dice
        int totalRolled = 0;
        for (int i = 0; i < numOfDie; i++)
        {
            totalRolled += Random.Range(1, dieSides);
        }

		return totalRolled;
    }
	
    /*
	public void TakeDamage(int val)
	{
		health -= val;
	} */
	
	public float GetCurrentHP()
	{
		return health;
	}

    public void TakeDamage(float dmg)
	{
		health -= (int) dmg;
		healthBar.SetHealth(health, maxHealth);
        print("Health: " + health + " MaxHealth: " + maxHealth);
	}

	public void UseMagic(float magic)
	{
		if((mana - magic) <= 0)
		{
            mana = 0;
		}

        mana -= (int)magic;
        magicBar.SetMagic(mana, maxMana);
    }

    public void CreateStatBars()
    {
        healthBar.SetHealth(health, maxHealth);
		magicBar.SetMagic(mana, maxMana);
    }
}
