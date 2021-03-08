using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    Background background;
    LevelLoader levelLoader;

    public void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();
        levelLoader = GameObject.Find("Code").transform.Find("Load Manager").GetComponent<LevelLoader>();
    }

    public void OnMagic()
    {
        UpgradeLibrary.IncrementMagicLvl();
        background.EnemyLevelUp();
        levelLoader.BasicLoad();
    }

    public void OnSpell()
    {
        UpgradeLibrary.IncrementSpellLvl();
        background.EnemyLevelUp();
        levelLoader.BasicLoad();
    }

    public void OnHealth()
    {
        UpgradeLibrary.IncrementHealthLvl();
        background.EnemyLevelUp();
        levelLoader.BasicLoad();
    }
}
