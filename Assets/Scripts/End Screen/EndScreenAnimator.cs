using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class EndScreenAnimator : MonoBehaviour
{

    public Camera backgroundCam;

    public Color winColour;
    public Color loseColour;

    public TextMeshPro FeedbackText;

    Color tempColour;

    Background background;

    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();
        tempColour = backgroundCam.backgroundColor;

        if (background.playerLost)
        {
            DOTween.To(() => tempColour, x => tempColour = x, loseColour, 2);
            FeedbackText.text = "You Lose";
        }
        else
        {
            DOTween.To(() => tempColour, x => tempColour = x, winColour, 2);
            FeedbackText.text = "You Win";
        }
    }

    // Update is called once per frame
    void Update()
    {
        backgroundCam.backgroundColor = tempColour;
    }
}
