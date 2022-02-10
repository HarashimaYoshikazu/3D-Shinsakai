using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGear : GearBase
{
    protected override void SetTransformGear()
    {
        this.transform.SetParent(HomeManager.Instance.BodyPanel.transform);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
