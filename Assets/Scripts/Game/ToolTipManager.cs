using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class ToolTipManager : MonoBehaviour
{

    float startTime;
    bool isHovering;
    bool isTweening;

    float toolTipDelay = 1f;

    GameObject toolTip;
    // Start is called before the first frame update
    void Start()
    {
        toolTip = transform.Find("ToolTip").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHovering)
        {
            if(Time.time - startTime >= toolTipDelay)
            {
                toolTip.SetActive(true);

                if (!isTweening)
                {
                    toolTip.transform.Find("Panel").GetComponent<Image>().DOColor(new Color(1,1,1,0), .5f).From().SetAutoKill(false);
                    toolTip.transform.Find("Arrow").Find("Arrow (1)").GetComponent<Image>().DOColor(new Color(1, 1, 1, 0), .5f).From().SetAutoKill(false);
                    isTweening = true;
                }
            }
        }
    }

    /// <summary>
    /// Called when user mouses over button
    /// </summary>
    public void OnEnterHover()
    {
        startTime = Time.time;
        isHovering = true;        
    }

    /// <summary>
    /// Called when user stops mousing over button
    /// </summary>
    public void OnExitHover()
    {
        isHovering = false;
        isTweening = false;
        toolTip.SetActive(false);
    }

    public void OnPointerClick()
    {
        isHovering = false;
        isTweening = false;
        toolTip.SetActive(false);
    }
}
