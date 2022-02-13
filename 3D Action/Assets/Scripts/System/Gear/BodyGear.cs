using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGear : GearBase
{
    protected override void OnEquip()
    {
        if (!GearManager.Instance.CurrentBodyGear)
        {
            //防御力UP
            PlayerPalam.Instance.Defencefluctuation(_addDefence);
            //頭パネルの子オブジェクトに
            this.transform.SetParent(HomeManager.Instance.BodyPanel.transform);

            //gearManagerの内部処理
            GearManager.Instance.OnEquip(this.gameObject);
        }
    }

    protected override void OnTakeOff()
    {
        //防御力元に戻す
        PlayerPalam.Instance.Defencefluctuation(-(_addDefence));
        //インベントリパネルの子オブジェクトに
        this.transform.SetParent(HomeManager.Instance.GearInventryPanel.transform);
        //gearManagerの内部処理
        GearManager.Instance.OnTakeOff(this.GetComponent<BodyGear>());
    }
}
