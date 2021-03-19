using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBars : MonoBehaviour
{
	public Slider health;
	public Slider magic;

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