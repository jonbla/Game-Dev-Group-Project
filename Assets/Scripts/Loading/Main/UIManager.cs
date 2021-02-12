using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Attack;
    public GameObject Magic;
    public GameObject Flee;

    public GameObject Punch;
    public GameObject Kick;
    public GameObject CastSpell;

    public GameObject row1;
    public GameObject row2;

    private void Start()
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

    public void OnAttack()
    {        
        Attack.SetActive(false);
        Magic.SetActive(false);
        Flee.SetActive(false);
        row2.SetActive(false);

        Punch.SetActive(true);
        Kick.SetActive(true);
    }

    public void OnMagic()
    {
        CastSpell.SetActive(true);

        Magic.SetActive(false);
        Flee.SetActive(false);
        row1.SetActive(false);

    }

    public void OnFlee()
    {
        print("AHHHHHHHHHH!");
    }

    public void OnCastSpell()
    {
        print("AbraKadabra");
    }

    public void OnPunch()
    {
        print("Punch!");
    }

    public void OnKick()
    {
        print("Kick!");
    }
}
