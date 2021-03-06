using UnityEngine;

/// <summary>
/// Backround Script responsible for Background Functions
/// </summary>
public class Background : MonoBehaviour
{
    /// <summary>
    /// Checks if main menu has been reloaded
    /// </summary>
    public bool reloadedMain = false;

    /// <summary>
    /// Current Enemy Tier
    /// </summary>
    public int enemyTier = 0;

    /// <summary>
    /// Flag to indicate if the player has lost or not
    /// </summary>
    public bool playerLost;

    /// <summary>
    /// First spell player is spawned with
    /// </summary>
    public static Spell spellOne = SpellHandler.spells["Fire Bolt"];

    /// <summary>
    /// Indicates if the game is on round 1 or 2 of the tier level
    /// </summary>
    public bool tierRematch = false;


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

    /// <summary>
    /// Increases enemy tier
    /// </summary>
    public void EnemyLevelUp()
    {
        enemyTier++;
    }
}
