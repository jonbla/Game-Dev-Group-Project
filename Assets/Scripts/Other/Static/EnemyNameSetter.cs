using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Info about enemy
/// </summary>
public class EnemyInfo
{
    public int graphic;
    public float health; //these two values
    public float mana;   //seem to not be used
}

/// <summary>
/// Gets info about an enemy of a certain tier
/// </summary>
public static class EnemyNameSetter
{
    public static EnemyInfo GetEnemyInfo(int tier)
    {
        EnemyInfo info = new EnemyInfo();
        if (tier < 4)
        {
            info.graphic = (tier*4) + Random.Range(0,4);
        }
        else
        {
            info.graphic = 16;
        }

        return info;
    }
}
