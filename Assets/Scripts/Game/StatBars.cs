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
		health.value = currentHP/maxHP;
	}

	public void SetMagic(float currentMP, float maxMP)
	{
		magic.value = currentMP/maxMP;
	}
}