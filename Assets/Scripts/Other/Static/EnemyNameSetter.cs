using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo
{
    public int graphic;
}

public static class EnemyNameSetter
{
    static string[,] names = new string[5,4] { {"Bat Evolution", "Beholder Evolution", "Blue Bat", "Glaring Eye" },
                                               {"Dark Slime","Brain Slime","Clay Slime","Elder Slime"},
                                               {"Dark Ghost","Beep Evolution","Evil Ghost","Floating Skull"},
                                               {"Centi Dragon Evolution","Dragon Horn","Boss Dragon","Cockatrice"},
                                               {"Dark Lord","Dark Lord","Dark Lord","Dark Lord"}
    };

    public static EnemyInfo GetEnemyInfo(int tier)
    {
        EnemyInfo info = new EnemyInfo();
        if (tier < 4)
        {
            info.graphic = tier + Random.Range(0, 3);
        }
        else
        {
            info.graphic = 17;
        }

        return info;
    }
}
