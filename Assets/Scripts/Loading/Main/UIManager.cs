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

    public GameObject row1;
    public GameObject row2;


    public void OnAttack()
    {
        print("attack");
        Attack.SetActive(false);
        Magic.SetActive(false);
        Flee.SetActive(false);
        Punch.SetActive(false);
        row2.SetActive(false);

        Punch.SetActive(true);
        Kick.SetActive(true);
    }

    public void OnMagic()
    {

    }

    public void OnFlee()
    {

    }
}
