using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public float maxHP;
	public float currentHP;

	public float maxMP;
	public float currentMP;

	public StatBars healthBar;
	public StatBars magicBar;

	void Start()
	{
		healthBar.SetHealth(currentHP, maxHP);
		magicBar.SetMagic(currentMP, maxMP);
	}

	void Update()
	{
		/*if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			TakeDamage(-5);
		}

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			TakeDamage(5);
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			UseMagic(1);
		}

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			UseMagic(-1);
		}*/
	}

	void TakeDamage(float dmg)
	{
		if((0 <= currentHP - dmg) && (maxHP >= currentHP - dmg))
		{
			currentHP -= dmg;
			healthBar.SetHealth(currentHP,maxHP);
		}
	}

	void UseMagic(float magic)
	{
		if((0 <= currentMP - magic) && (maxMP >= currentMP - magic))
		{
			currentMP -= magic;
			magicBar.SetMagic(currentMP,maxMP);
		}
	}

}