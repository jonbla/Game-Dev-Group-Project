using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public void OnMagic()
    {
        UpgradeLibrary.IncrementMagicLvl();
    }

    public void OnSpell()
    {
        UpgradeLibrary.IncrementSpellLvl();
    }

    public void OnHealth()
    {
        UpgradeLibrary.IncrementHealthLvl();
    }
}
