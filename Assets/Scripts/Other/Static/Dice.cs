using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dice
{
    /// <summary>
    /// Rolls dice of given dimentions
    /// </summary>
    /// <param name="numOfDie">Number of die to roll</param>
    /// <param name="dieSides">Number of sides each die has</param>
    /// <returns>Sum of all rolled die</returns>
    public static int RollDice(int numOfDie, int dieSides)
    {
        // ie, RollDice(2,6) would roll two 6 sided dice
        int totalRolled = 0;
        for (int i = 0; i < numOfDie; i++)
        {
            totalRolled += Random.Range(1, dieSides);
        }
        return totalRolled;
    }
}
