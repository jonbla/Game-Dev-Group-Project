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

    [Range(0, 160)]
    public int health;
    [Range(0, 160)]
    public int maxHealth;
    [Range(0, 10)]
    public int maxMana;
    [Range(0, 10)]
    public int mana;

    public int tier;
    public int damage = 5;

    public PlayerStats playerStats;

    TextMeshPro nameText;
    PlayerStats player;


    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponentInChildren<TextMeshPro>();
        player = GameObject.Find("Code").transform.Find("Player Stats").GetComponent<PlayerStats>();

        nameText.text = enemyName;
        GameObject tempPlayer;
        tempPlayer = GameObject.Find("Player Stats");
        playerStats = tempPlayer.GetComponent<PlayerStats>();
    }

    public void DoTurn()
    {
        int tmpdmg = 0;
        print("Enemy turn");

        switch (DecideAction()){
            case 0: //just deal damage
                //TODO: decrease player health by amount (waiting on player stats)
                //player.health -= damage;
                        playerStats.TakeDamage(damage);
                    ;break;

    // HEALING SPELLS #######################################################
            case 1: //we are going to heal t1
                mana -= 4;
                health += RollDice(2,12);
                    ;break;
            case 4: //we are going to heal t2
                mana -= 5;
                health += RollDice(3,12);
                    ;break;
            case 5: //we are going to heal t3
                mana -= 6;
                health += RollDice(4,12);
                    ;break;
            case 6: //we are going to heal t4
                mana -= 4;
                health += RollDice(5,12) + 15;
                    ;break;
    // OFFENSIVE SPELLS #######################################################
            case 2: // WhistleStrike
                mana -= 1;
                playerStats.TakeDamage(RollDice(2,4));
                playerStats.UseMagic(-1);
                    ;break;
            case 3: // FireBolt
                mana -= 2;
                playerStats.TakeDamage(RollDice(2,8));
                playerStats.UseMagic(-2);
                    ;break;

            case 7: // lightingBolt
                mana -= 5;
                playerStats.TakeDamage(RollDice(3,10));
                playerStats.UseMagic(-5);
                    ;break;
            case 8: // dark dagger - Bolt
                mana -= 3;
                playerStats.TakeDamage(RollDice(3,8));
                playerStats.UseMagic(-3);
                    ;break;
            case 9: // lightingBolt
                mana -= 6;
                playerStats.TakeDamage(RollDice(5,8));
                playerStats.UseMagic(-6);
                    ;break;
            case 10: // dark dagger - Bolt
                mana -= 4;
                tmpdmg = RollDice(3,8);
                playerStats.TakeDamage(tmpdmg);
                health += tmpdmg;
                playerStats.UseMagic(-4);
                    ;break;
            case 11: // lightingBolt
                mana -= 8;
                playerStats.TakeDamage(RollDice(5,12));
                playerStats.UseMagic(-8);
                    ;break;
            case 12: // dark dagger - Bolt
                mana -= 7;
                tmpdmg = RollDice(6,8);
                playerStats.TakeDamage(tmpdmg);
                health -= tmpdmg /4;
                playerStats.UseMagic(-7);
                    ;break;
            default:
                playerStats.TakeDamage(damage); 
                    ;break;
        }
    }
    
    public int DecideAction(){
        // we have some mana, lets see if we can cast a spell
        if (mana > 0){
            if (health <= maxHealth/2){
                //try and cast heal spell
                if (tier>=4){
                    if (mana >= 8) {
                        return 6; //HEAL 4
                    }
                }
                if (tier>=3){
                    if (mana >= 6) {
                        return 5; //HEAL 3
                    }
                }
                if (tier>=2){
                    if (mana >= 5) {
                        return 4; //HEAL 2
                    }
                }
                if (tier>=1){
                    if (mana >= 4) {
                        return 1;
                    }
                }
            }
            // our health is good, lets try and cast a offensive spell (as potent as possible)
            if (tier>=3){
                if (mana >= 8){
                    return 12;          //DAMAGE 5
                } else if (mana >= 7){
                    return 11;          //DAMAGE 6
                    }
                }
            
            if (tier>=2){
                if (mana >= 6){
                    return 10;          //DAMAGE 3
                } else if (mana >= 4){
                    return 9;           //DAMAGE 4
                    }
                }
            
            if (tier>=1){
                if (mana >= 5){
                    return 8;           //DAMAGE 2
                } else if (mana >= 3){
                    return 7;           //DAMAGE 1
                    }
                }
            
            if (tier>=0){
                if (mana >= 3){
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
	
	public void TakeDamage(int val)
	{
		health -= val;
	}
	
	public float GetCurrentHP()
	{
		return health;
	}
}
