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

    public EnemyInfo(int graphic)
    {
        this.graphic = graphic;
    }

    public EnemyInfo()
    {

    }
}

/// <summary>
/// Gets info about an enemy of a certain tier
/// </summary>
public static class EnemyNameSetter
{
    //Keeps track of which enemies were already defeated, so two enemies are not called twice in one tier
    static EnemyInfo tier0Enemy = new EnemyInfo(-1);
    static EnemyInfo tier1Enemy = new EnemyInfo(-1);
    static EnemyInfo tier2Enemy = new EnemyInfo(-1);
    static EnemyInfo tier3Enemy = new EnemyInfo(-1);

    static EnemyInfo temp = new EnemyInfo(-1);

    public static EnemyInfo GetEnemyInfo(int tier)
    {
        EnemyInfo info = new EnemyInfo();
        if (tier < 4)
        {
            info.graphic = (tier*4) + Random.Range(0,4);
            switch (tier)
            {
                case 0:
                    temp = tier0Enemy;
                    break;

                case 1:
                    temp = tier1Enemy;
                    break;

                case 2:
                    temp = tier2Enemy;
                    break;

                case 3:
                    temp = tier3Enemy;
                    break;

            }

            if(info.graphic == temp.graphic)
            {
                info.graphic = GetEnemyInfo(tier).graphic;
            }

            temp = info;

        }
        else
        {
            info.graphic = 16;
        }

        return info;
    }
}
