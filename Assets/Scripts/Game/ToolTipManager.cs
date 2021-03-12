using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnterHover()
    {
        print("Make Tooltip");
    }

    public void OnExitHover()
    {
        print("Remove Tooltip");
    }
}
