using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public float maxHP;
	public float currentHP;

	public float maxMP;
	public float currentMP;

	public StatBars healthBar;
	public StatBars magicBar;

	public Text HPText;
	public Text MPText;

    public bool readyToKill = false;
    bool isTweening = false;    

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

		HPText.text = currentHP.ToString() + "/" + maxHP.ToString();
		MPText.text = currentMP.ToString() + "/" + maxMP.ToString();
	}

	void Update()
	{
		if (currentHP > maxHP){
            currentHP = maxHP;
        }
        if (currentMP > maxMP){
            currentMP = maxMP;
        }
        
        HPText.text = currentHP.ToString() + "/" + maxHP.ToString();
        MPText.text = currentMP.ToString() + "/" + maxMP.ToString();

        if (isTweening)
        {
            healthBar.SetHealth(currentHP, maxHP);
            magicBar.SetMagic(currentMP, maxMP);

            HPText.text = Mathf.RoundToInt(currentHP).ToString() + "/" + maxHP.ToString();
            MPText.text = Mathf.RoundToInt(currentMP).ToString() + "/" + maxMP.ToString();
        }
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

    public void DoInfoBarAnimation()
    {
        if (isTweening)
        {
            return;
        }
        isTweening = true;
        DOTween.To(() => currentHP, x => currentHP = x, 100, 2).SetAutoKill(true);
        DOTween.To(() => currentMP, x => currentMP = x, 50, 2).SetAutoKill(true).OnComplete(ReportFinishedAnimation);
    }

    void ReportFinishedAnimation()
    {
        isTweening = false;
        readyToKill = true;
    }

}