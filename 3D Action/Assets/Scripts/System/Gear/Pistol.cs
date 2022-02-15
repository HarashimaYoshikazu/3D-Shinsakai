using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GearBase
{
    protected override void OnEquip()
    {
        //この装備を装備中のパネル
        this.transform.SetParent(HomeManager.Instance.CurrentWeaponPanel.transform);

        //現在の武器を変更

    }

    protected override void OnTakeOff()
    {
        throw new System.NotImplementedException();
    }
}
