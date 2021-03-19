using UnityEngine;

/// <summary>
/// Backround Script responsible for Background Functions
/// </summary>
public class Background : MonoBehaviour
{

    public bool reloadedMain = false;

    /// <summary>
    /// Current Enemy Tier
    /// </summary>
    public int enemyTier = 0;
    public bool playerLost;
    public static Spell spellOne = SpellHandler.spells["Fire Bolt"];


    void Start()
    {
        //Resolves duplication issue
        GameObject [] gameObjects = GameObject.FindGameObjectsWithTag("Background");
        if(gameObjects.Length >= 2)
        {
            Destroy(gameObjects[gameObjects.Length - 1].gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void EnemyLevelUp()
    {
        enemyTier++;
    }
}
