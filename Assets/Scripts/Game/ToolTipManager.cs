using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipManager : MonoBehaviour
{

    float startTime;
    bool isHovering;

    float toolTipDelay = 1f;

    GameObject toolTip;
    // Start is called before the first frame update
    void Start()
    {
        toolTip = transform.Find("ToolTip").gameObject;
        isHovering = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHovering)
        {
            if(Time.time - startTime >= toolTipDelay)
            {
                toolTip.SetActive(true);
            }
        }
    }

    public void OnEnterHover()
    {
        startTime = Time.time;
        isHovering = true;
        
    }

    public void OnExitHover()
    {
        isHovering = false;
        toolTip.SetActive(false);
    }
}
