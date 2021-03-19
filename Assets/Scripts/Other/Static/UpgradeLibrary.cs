using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradeLibrary
{
    //This get incremented by the upgrade screen
    static int healthLvl = 0;
    static int spellLvl = 1;
    static int magicLvl = 0;

    //These are the upgrade values based on the upgrade screen
    static readonly int[] healthBonus = {0, 15, 30, 40, 50 };
    static readonly int[] magicBonus = {0, 15, 30, 40, 50 };

    /// <summary>
    /// Sets upgrade level of health
    /// </summary>
    public static int HealthLvl { set => healthLvl = value; }

    /// <summary>
    /// Sets upgrade level of Spells
    /// </summary>
    public static int SpellLvl { set => spellLvl = value; }

    /// <summary>
    /// Sets upgrade level of Magic
    /// </summary>
    public static int MagicLvl { set => magicLvl = value; }    

    /// <summary>
    /// Gets The Health Bonus based on the current health level
    /// </summary>
    /// <returns>How much max health to be added</returns>
    public static int GetHealthBonus()
    {
        return healthBonus[healthLvl];
    }

    /// <summary>
    /// Gets The Magic Bonus based on the current magic level
    /// </summary>
    /// <returns>How much max MP to be added</returns>
    public static int GetMagicBonus()
    {
        return magicBonus[magicLvl];
    }

    /// <summary>
    /// Gets Spell Level
    /// </summary>
    /// <returns>Spell Level</returns>
    public static int GetSpellLvl()
    {
        return spellLvl;
    }

    public static void IncrementHealthLvl() {healthLvl++;}
    public static void IncrementMagicLvl() { magicLvl++; }
    public static void IncrementSpellLvl() { spellLvl++; }
}
