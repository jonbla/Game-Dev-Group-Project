using TMPro;
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
    public MusicController musicController;

    public GameObject popupPrefab;

    //Set the default configuration on start
    private void Start()
    {
        fightManager = GameObject.Find("Code").transform.Find("Fight Manager").GetComponent<FightManager>();
        musicController = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>();
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
            CastSpell.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = spellOne.name;
        else
            CastSpell.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Background.spellOne.name;
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
            PlayerFeedback("Not Enough Mana");
            FightMenu();
            return;
        }
        dmg = Dice.RollDice(spellOne.rolls, spellOne.dieType);

        if (dmg < 0) //Heals player if damage is negative
        {
            player.TakeDamage(dmg);
            player.UseMagic(spellOne.cost);
            print("Spell healed: " + dmg);
        }
        else //Otherwise, damages enemy
        {
            enemy.TakeDamage(dmg);
            player.UseMagic(spellOne.cost);
            print("Spell damage: " + dmg);
        }

        if ((enemy.mana + spellOne.cost) > enemy.maxMana)
        {
            enemy.mana = enemy.maxMana;
        }
        else
        {
            enemy.mana += spellOne.cost;
        }
        musicController.PlayerMagicSound.Play();

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
        musicController.PunchSound.Play();
        FightMenu();
    }

    /// <summary>
    /// Called when Kick button is pressed
    /// </summary>
    public void OnKick()
    {
        if (Random.Range(0, 3) != 0)
        {
            print("Kick!");
            enemy.TakeDamage(15);
            print("Kick damage: 15");
            musicController.PunchSound.Play();
        }
        else
        {
            print("Kick missed! No damage done.");
            PlayerFeedback("Miss!");
        }
        
        fightManager.ToggleTurn();

        FightMenu();
    }

    void PlayerFeedback(string text)
    {
        TextMeshPro feedbackTextObject = Instantiate(popupPrefab).GetComponent<TextMeshPro>();
        feedbackTextObject.text = text;
    }
}
