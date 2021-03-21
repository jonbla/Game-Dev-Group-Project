using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spell
{
    public string name;
    // Number of rolls of the die, and what type of die ie d6, d7 etc..
    public int rolls, dieType; 
    public int tier;
    public int cost;

    /// <summary>
    /// Spell Object
    /// </summary>
    /// <param name="_name">Name of spell</param>
    /// <param name="_rolls">How many dice to roll</param>
    /// <param name="_dieType">How many sides dice has</param>
    /// <param name="_tier">Spell tier</param>
    /// <param name="_cost">Mana cost to use spell</param>
    public Spell(string _name, int _rolls, int _dieType, int _tier, int _cost)
    {
        name = _name;
        rolls = _rolls;
        dieType = _dieType;
        tier = _tier;
        cost = _cost;
    }

    /// <summary>
    /// String representation of Spell
    /// </summary>
    /// <returns>Name</returns>
    public override string ToString()
    {
        return name;
    }
}


public static class SpellHandler
{
    public static Dictionary<string, Spell> spells = new Dictionary<string, Spell>();
    public static List<string> spellNames = new List<string>();
    public static List<Spell> rawSpells = new List<Spell>();
    static SpellHandler()
    {
        //When adding spells to the game, use the same syntax as below.
        //DO NOT TRY TO ADD SPELLS MORE MANUALLY THAN THIS
        //This will gurantee that the spell gets added to the dictionary as well as the list
        //in the correct order and way. good luck
        //Parameters: name, rolls, dieType, tier, cost

        //Tier 1 spells
        AddSpell("Fire Bolt", 3, 6, 1, 20);
        AddSpell("Whistling Strike", 3, 4, 1, 10);
        //AddSpell("Minor Heal",2,-12,1,4);
        //Tier 2 spells
        AddSpell("Lightning Bolt",3,10,2,50);
        AddSpell("Dark Daggers",3,8,2,30);
        //AddSpell("Rejuvenating Heal",3,-12,2,5);
        //AddSpell("Minor Mana Drain",3,10,2,0); //Not sure if this spell would work with this system, so I'm leaving it out for now (No way to affect MP)
        //Tier 3 spells
        AddSpell("Fireball",5,8,3,60);
        //AddSpell("Lifedrain",2,8,3,4); //No way to deal damage and heal at same time
        //AddSpell("Major Heal",4,-12,3,6);
        //Tier 4 spells
        AddSpell("Fireblast",5,12,4,80);
        AddSpell("Aggressive Charge",6,8,4,60); //Won't deal damage to caster as it stands
        //AddSpell("Superb Heal",5,10,4,8);
        //AddSpell("Lightning Bolt",3,10,4,5); //Not sure if this spell would work with this system, so I'm leaving it out for now (No way to affect MP)
    }

    /// <summary>
    /// Add Spell to spellbook
    /// </summary>
    /// <param name="name">Name of spell</param>
    /// <param name="rolls">How many dice to roll</param>
    /// <param name="dieType">How many sides dice has</param>
    /// <param name="tier">Spell tier</param>
    /// <param name="cost">Mana cost to use spell</param>
    private static void AddSpell(string name, int rolls, int dieType, int tier, int cost)
    {
        spellNames.Add(name);
        rawSpells.Add(new Spell(name, rolls, dieType, tier, cost));
        spells.Add(name, new Spell(name, rolls, dieType, tier, cost));

    }

    public static Spell GetRandomSpell()
    {
        int size = spellNames.Count;
        string randomName = spellNames[Random.Range(0, size)];
        return spells[randomName];
    }


    /// <summary>
    /// Returns a random spell of a certain tier
    /// </summary>
    /// <param name="tier">Target tier</param>
    /// <returns>Random spell of target tier, Returns Null if false</returns>
    public static Spell GetRandomSpell(int tier)
    {
        List<Spell> tempList = new List<Spell>();
        for (int i = 0; i < rawSpells.Count; i++)
        {
            if (rawSpells[i].tier == tier)
                tempList.Add(rawSpells[i]);
        }
        if (tempList.Count == 0)
            return null;
        
        return tempList[Random.Range(0, tempList.Count)];
    }

    //This function will start the tier given to it and find a random spell of that tier.
    //If one does not exist it will get a spell of the next lowest tier.
    //And so on and so forth. If it never finds a spell by the time it get to tier '0'
    //It will return null.

    /// <summary>
    /// This function will start the tier given to it and find a random spell of that tier
    /// </summary>
    /// <param name="tier">Target tier</param>
    /// <returns>Spell of target tier, returns null if no spell is found</returns>
    public static Spell GetRandomSpellUnderTier(int tier)
    {
        Spell toRet;
        for (int i = tier; i > 0; i--)
        {
            toRet = GetRandomSpell(i);
            if (toRet != null)
                return toRet;
        }
        return null;
    }
}
