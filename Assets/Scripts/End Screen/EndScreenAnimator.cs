using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndScreenAnimator : MonoBehaviour
{

    public Camera mainCam;
    public Color winColour;
    public Color loseColour;

    Background background;

    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();

        if (background.playerLost)
        {
            mainCam.DOColor(loseColour, 1f);
        }
        else
        {
            mainCam.DOColor(winColour, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
