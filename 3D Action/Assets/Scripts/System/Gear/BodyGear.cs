using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGear : GearBase
{
    protected override void SetTransformGear()
    {
        this.transform.SetParent(HomeManager.Instance.BodyPanel.transform);
        if (GearManager.Instance.CurrentBodyGear)
        {
            GearManager.Instance.CurrentBodyGear.transform.SetParent(HomeManager.Instance.GearInventryPanel.transform);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
