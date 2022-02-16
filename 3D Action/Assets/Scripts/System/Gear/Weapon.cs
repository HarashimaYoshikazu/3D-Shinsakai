using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GearBase
{
    protected override void OnEquip()
    {
        //この装備を装備中のパネル
        this.transform.SetParent(HomeManager.Instance.CurrentWeaponPanel.transform);
        WeaponManager.Instance.HomeSceneGunIcon.transform.SetParent(HomeManager.Instance.WeaponInventryPanel.transform);

        //現在の武器を変更
        WeaponManager.Instance.Equip(this.gameObject);
    }

    protected override void OnTakeOff()
    {
        Debug.Log("武器は外すことができません");
    }
}
