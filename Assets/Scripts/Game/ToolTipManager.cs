using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipManager : MonoBehaviour
{

    GameObject toolTip;
    // Start is called before the first frame update
    void Start()
    {
        toolTip = transform.Find("ToolTip").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnterHover()
    {
        toolTip.SetActive(true);
    }

    public void OnExitHover()
    {
        toolTip.SetActive(false);
    }
}
