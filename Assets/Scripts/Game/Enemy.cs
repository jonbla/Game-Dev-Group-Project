using System.ComponentModel;
using TMPro;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Controller for Enemy prefab
/// </summary>
public class Enemy : MonoBehaviour
{

    public class ReadOnlyAttribute : PropertyAttribute
    {

    }

    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property,
                                                GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position,
                                   SerializedProperty property,
                                   GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }

    /// <summary>
    /// Name of spawned enemy
    /// </summary>
    public string enemyName;

    [Range(0, 100)]
    [ReadOnly]
    public int health = 100;
    [Range(0, 10)]
    public int mana = 10;

    public int damage = 5;

    TextMeshPro nameText;
    PlayerStats player;


    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponentInChildren<TextMeshPro>();
        player = GameObject.Find("Code").transform.Find("Player Stats").GetComponent<PlayerStats>();

        nameText.text = enemyName;
    }

    public void DoTurn()
    {
        print("Enemy turn");

        player.TakeDamage(10); //placeholder code

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
