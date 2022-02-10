using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGear : GearBase
{
    protected override void SetTransformGear()
    {
        this.transform.SetParent(HomeManager.Instance.HeadPanel.transform);
        if (GearManager.Instance.CurrentHeadGear)
        {
            GearManager.Instance.CurrentHeadGear.transform.SetParent(HomeManager.Instance.GearInventryPanel.transform);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
