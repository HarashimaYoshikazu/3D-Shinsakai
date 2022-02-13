using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGear : GearBase
{
    protected override void OnEquip()
    {
        //防御力UP
        PlayerPalam.Instance.Defencefluctuation(_addDefence);
        //頭パネルの子オブジェクトに
        this.transform.SetParent(HomeManager.Instance.HeadPanel.transform);

        //gearManagerの内部処理
        GearManager.Instance.OnEquip(this.gameObject);
    }

    protected override void OnTakeOff()
    {
        //防御力元に戻す
        PlayerPalam.Instance.Defencefluctuation(-(_addDefence));
        //インベントリパネルの子オブジェクトに
        this.transform.SetParent(HomeManager.Instance.GearInventryPanel.transform);
        //gearManagerの内部処理
        GearManager.Instance.OnTakeOff();
    }
}
