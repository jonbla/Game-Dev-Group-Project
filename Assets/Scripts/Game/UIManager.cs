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

    //Set the default configuration on start
    private void Start()
    {
        FightMenu();
    }

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
        if (!FightManager.playerTurn)
            return;
        FightManager.playerTurn = false;
        print("AHHHHHHHHHH!");

        FightMenu();
    }

    /// <summary>
    /// Called when Cast Spell button is pressed
    /// </summary>
    public void OnCastSpell()
    {
        print("AbraKadabra");
        print("A random spell is: " + SpellHandler.GetRandomSpell());
        FightManager.playerTurn = false;

        FightMenu();
    }

    /// <summary>
    /// Called when Punch button is pressed
    /// </summary>
    public void OnPunch()
    {
        print("Punch!");
        FightManager.playerTurn = false;

        FightMenu();
    }

    /// <summary>
    /// Called when Kick button is pressed
    /// </summary>
    public void OnKick()
    {
        print("Kick!");
        FightManager.playerTurn = false;
        
        FightMenu();
    }
}
