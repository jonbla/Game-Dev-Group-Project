using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	float maxHP;
	float currentHP;

	float maxMP;
	float currentMP;

	public StatBars healthBar;
	public StatBars magicBar;

	void Start()
	{
        maxHP = 100f;
        maxMP = 100f;

        //Applies upgrade bonuses to HP and MP
        maxHP += UpgradeLibrary.GetHealthBonus();
        maxMP += UpgradeLibrary.GetMagicBonus();

        currentHP = maxHP;
        currentMP = maxMP;

		healthBar.SetHealth(currentHP, maxHP);
		magicBar.SetMagic(currentMP, maxMP);
	}

	void Update()
	{
		/*OnDebugging();*/
	}

	public void TakeDamage(float dmg)
	{
		currentHP -= dmg;
		healthBar.SetHealth(currentHP, maxHP);
	}

	public void UseMagic(float magic)
	{
		if((currentMP - magic) <= 0)
		{
            currentMP = 0;
            print("no mana, no spell, no damage. Sorry");
            return;
		}

        currentMP -= magic;
        magicBar.SetMagic(currentMP, maxMP);
    }

    public float GetCurrentHP()
    {
        return currentHP;
    }

    public float GetCurrentMP()
    {
        return currentMP;
    }

    void OnDebugging()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TakeDamage(-5);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TakeDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UseMagic(1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UseMagic(-1);
        }
    }

}