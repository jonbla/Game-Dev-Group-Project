using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public Camera cam;
    public Color bgColour;

    bool setBG = true;

    Background bgScript;

    // Start is called before the first frame update
    void Start()
    {
        cam.backgroundColor = bgColour;
        try
        {
            bgScript = GameObject.Find("Background Process").GetComponent<Background>();
        } catch(System.NullReferenceException)
        {
            return;
        }
        if (!bgScript.reloadedMain)
        {
            bgScript.reloadedMain = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (setBG)
        {
            cam.backgroundColor = bgColour;
        }
    }

    public void UnlockBG()
    {
        setBG = false;
    }

    public void DeleteEventSystem()
    {
        Destroy(GameObject.Find("EventSystem"));
    }
    
}
