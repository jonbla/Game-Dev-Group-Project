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
        currentMP = maxMP/2;

		healthBar.SetHealth(currentHP, maxHP);
		magicBar.SetMagic(currentMP, maxMP);
	}

	void Update()
	{
		/*OnDebugging();*/
	}

    /// <summary>
    /// Removes health from player and updates healthbar
    /// </summary>
    /// <param name="dmg">Damage to take</param>
	public void TakeDamage(float dmg)
	{
		currentHP -= dmg;
		healthBar.SetHealth(currentHP, maxHP);
	}

    /// <summary>
    /// Removes mana from player and updates manabar
    /// </summary>
    /// <param name="magic">Mana to deplete</param>
	public void UseMagic(float magic)
	{
		if((currentMP - magic) <= 0)
		{
            currentMP = 0;
		}

        currentMP -= magic;
        magicBar.SetMagic(currentMP, maxMP);
    }

    /// <summary>
    /// Returns Player's current health
    /// </summary>
    /// <returns>health</returns>
    public float GetCurrentHP()
    {
        return currentHP;
    }

    /// <summary>
    /// Returns Player's current mana
    /// </summary>
    /// <returns>MP</returns>
    public float GetCurrentMP()
    {
        return currentMP;
    }

    /// <summary>
    /// Debugging mode
    /// </summary>
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