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
    [Range(0, 10)]
    public int mana;

    public int damage = 5;

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
        switch (DecideAction()){
            case 0: //just deal damage
                //TODO: decrease player health by amount (waiting on player stats)
                //player.health -= damage;
                    ;break;
            case 1: //we are going to heal
                mana -= 4;
                health += RollDice(2,12);
                    ;break;
            case 2: // WhistleStrike
                mana -= 1;
                RollDice(2,4);
                //TODO: decrease player health by amount (waiting on player stats)
                    ;break;
            case 3: // FireBolt
                mana -= 1;
                RollDice(2,8);
                //TODO: decrease player health by amount (waiting on player stats)
                    ;break;
            default:
                // punch the enemy 
                    ;break;
        }
    }

    public int DecideAction(){
        // we have some mana, lets see if we can cast a spell
        if (mana > 0){
            if (health <= 50){
                //try and cast heal spell
                if (mana >= 4) {
                    return 1;
                }
            }
            // our health is good, lets try and cast a offensive spell (as potent as possible)
            if (mana >= 3){
                return 3;
            } else if (mana > 0){
                return 2;
                }
            }
        // we don't want to cast a spell, use default damage
         return 0;
    }

    private int RollDice(int numOfDie, int dieSides){
        // ie, RollDice(2,6) would roll two 6 sided dice
        int totalRolled = 0;
        for (int i = 0; i < numOfDie; i++){
        totalRolled += Random.Range(1, dieSides);
        }

        return totalRolled;
    }
}
