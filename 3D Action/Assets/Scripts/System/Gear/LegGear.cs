using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegGear : GearBase
{
    protected override void OnEquip()
    {
        //防御力UP
        PlayerPalam.Instance.Defencefluctuation(_addDefence);
        //頭パネルの子オブジェクトに
        this.transform.SetParent(HomeManager.Instance.LegPanel.transform);

        //gearManagerの内部処理
        GearManager.Instance.OnEquip(this.gameObject);
    }

    protected override void OnTakeOff()
    {
        throw new System.NotImplementedException();
    }
}
