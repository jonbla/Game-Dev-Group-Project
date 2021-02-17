using UnityEngine;

/// <summary>
/// Backround Script responsible for Background Functions
/// </summary>
public class Background : MonoBehaviour
{

    public bool reloadedMain = false;


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
