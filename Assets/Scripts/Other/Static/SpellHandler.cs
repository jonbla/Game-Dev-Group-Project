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

    public Spell(string _name, int _rolls, int _dieType, int _tier, int _cost)
    {
        name = _name;
        rolls = _rolls;
        dieType = _dieType;
        tier = _tier;
        cost = _cost;
    }

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
        AddSpell("Fire Bolt", 3, 6, 1, 2);
        AddSpell("Whistling Strike", 2, 4, 1, 1);
    }

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

    //Returns a random spell of a certain tier
    //If no such spell exists, it will return null.
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
