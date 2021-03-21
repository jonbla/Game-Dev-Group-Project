using UnityEngine;

/// <summary>
/// Manages The Main Game UI
/// </summary>
public class UIManager : MonoBehaviour
{
    //These are refences to the buttons
    public GameObject Attack;
    public GameObject Magic;
    public GameObject Flee;

    public GameObject Punch;
    public GameObject Kick;
    public GameObject CastSpell;

    public GameObject row1;
    public GameObject row2;

    FightManager fightManager;
    Spell spellOne;
    PlayerStats player;
    Enemy enemy;

    private int dmg;

    //Set the default configuration on start
    private void Start()
    {
        fightManager = GameObject.Find("Code").transform.Find("Fight Manager").GetComponent<FightManager>();

        //These two pieces of code allow us to edit player and enemy stats inside this script
        player = GameObject.Find("Code").transform.Find("Player Stats").GetComponent<PlayerStats>();
        enemy = GameObject.Find("Enemy(Clone)").GetComponent<Enemy>();

        FightMenu();        
    }

    /// <summary>
    /// Resets fight Menu
    /// </summary>
    public void FightMenu()
    {
        Attack.SetActive(true);
        Magic.SetActive(true);
        Flee.SetActive(true);
        row1.SetActive(true);
        row2.SetActive(true);

        Punch.SetActive(false);
        Kick.SetActive(false);
        CastSpell.SetActive(false);
    }

    /// <summary>
    /// Called when Attack button is pressed
    /// </summary>
    public void OnAttack()
    {        
        Attack.SetActive(false);
        Magic.SetActive(false);
        Flee.SetActive(false);
        row2.SetActive(false);

        Punch.SetActive(true);
        Kick.SetActive(true);
    }

    /// <summary>
    /// Called when Magic button is pressed
    /// </summary>
    public void OnMagic()
    {
        if (this.spellOne != null)
            CastSpell.transform.GetChild(0).gameObject.GetComponent<TMPro.TMP_Text>().text = spellOne.name;
        else
            CastSpell.transform.GetChild(0).gameObject.GetComponent<TMPro.TMP_Text>().text = Background.spellOne.name;
        CastSpell.SetActive(true);

        Magic.SetActive(false);
        Flee.SetActive(false);
        row1.SetActive(false);

    }

    /// <summary>
    /// Called when Flee button is pressed
    /// </summary>
    public void OnFlee()
    {
        if (!fightManager.getIsPlayerTurn())
            return;
        fightManager.Flee();
    }

    /// <summary>
    /// Called when Cast Spell button is pressed
    /// </summary>
    public void OnCastSpell()
    {
        print("AbraKadabra");
        spellOne = Background.spellOne;
        print("A random spell is: " + spellOne);
        if (player.GetCurrentMP() < spellOne.cost)
        {
            print("no mana, no spell, no damage. Sorry");
            FightMenu();
            return;
        }
        dmg = RollDice(spellOne.rolls, spellOne.dieType);
        enemy.TakeDamage(dmg);
        player.UseMagic(spellOne.cost);
        if ((enemy.mana + spellOne.cost) > enemy.maxMana)
        {
            enemy.mana = enemy.maxMana;
        }
        else
        {
            enemy.mana += spellOne.cost;
        }
        print("Spell damage: " + dmg);
        fightManager.ToggleTurn();

        FightMenu();
    }

    /// <summary>
    /// Called when Punch button is pressed
    /// </summary>
    public void OnPunch()
    {
        print("Punch!");
        enemy.TakeDamage(5);
        print("Punch damage: 5");
        fightManager.ToggleTurn();

        FightMenu();
    }

    /// <summary>
    /// Called when Kick button is pressed
    /// </summary>
    public void OnKick()
    {
        print("Kick!");
        enemy.TakeDamage(5);
        print("Kick damage: 5");
        fightManager.ToggleTurn();

        FightMenu();
    }

    /// <summary>
    /// Calculates damage for spells
    /// </summary>
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
}
