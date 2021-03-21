using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBars : MonoBehaviour
{
	public Slider health;
	public Slider magic;

    /// <summary>
    /// Set HealthBar value
    /// </summary>
    /// <param name="currentHP">Current health</param>
    /// <param name="maxHP">Max possible health</param>
	public void SetHealth(float currentHP, float maxHP)
	{
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        if (currentHP <= 0)
        {
            currentHP = 0;
        }

		health.value = currentHP/maxHP;
	}

    /// <summary>
    /// Set Mana value
    /// </summary>
    /// <param name="currentMP">Current mana</param>
    /// <param name="maxMP">Max possible mana</param>
	public void SetMagic(float currentMP, float maxMP)
	{
        if(currentMP > maxMP)
        {
            currentMP = maxMP;
        }

        if (currentMP <= 0)
        {
            currentMP = 0;
        }

        magic.value = currentMP/maxMP;
	}
}