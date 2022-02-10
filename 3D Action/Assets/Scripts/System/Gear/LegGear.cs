using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegGear : GearBase
{
    protected override void SetTransformGear()
    {
        this.transform.SetParent(HomeManager.Instance.LegPanel.transform);
        if (GearManager.Instance.CurrentLegGear)
        {
            GearManager.Instance.CurrentLegGear.transform.SetParent(HomeManager.Instance.GearInventryPanel.transform);
        }
    }

}
