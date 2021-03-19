using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    Background background;
    LevelLoader levelLoader;
    MusicController soundmanager;
    public void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();
        levelLoader = GameObject.Find("Code").transform.Find("Load Manager").GetComponent<LevelLoader>();
        soundmanager = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>();
        soundmanager.StopAll();
        soundmanager.UpgradeMusic.Play();
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
        Background.spellOne = SpellHandler.GetRandomSpellUnderTier(UpgradeLibrary.GetSpellLvl());
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
