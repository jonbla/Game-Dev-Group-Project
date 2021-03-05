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

		health.value = currentHP/maxHP;
	}

	public void SetMagic(float currentMP, float maxMP)
	{
        if(currentMP > maxMP)
        {
            currentMP = maxMP;
        }

		magic.value = currentMP/maxMP;
	}
}