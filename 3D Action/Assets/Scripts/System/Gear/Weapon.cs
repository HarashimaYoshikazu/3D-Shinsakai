using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GearBase
{
    [SerializeField, Tooltip("射撃速度の増加数")]
    float _addLate = -0.7f;

    [SerializeField, Tooltip("射撃ダメージの追加")]
    int _addDamage = 5;
    protected override void OnEquip()
    {
        //射撃速度増加
        PlayerPalam.Instance.FireIntervalfluctuation(_addLate);

        //火力UP
        PlayerPalam.Instance.Attackfluctuation(_addDamage);

        //この装備を装備中のパネル
        this.transform.SetParent(HomeManager.Instance.CurrentWeaponPanel.transform);
        WeaponManager.Instance.HomeSceneGunIcon.transform.SetParent(HomeManager.Instance.WeaponInventryPanel.transform);

        //現在の武器を変更
        WeaponManager.Instance.Equip(this.gameObject);
    }

    protected override void OnTakeOff()
    {
        //もとに戻す
        PlayerPalam.Instance.FireIntervalfluctuation(-(_addLate));

        PlayerPalam.Instance.Attackfluctuation(-(_addDamage));
        Debug.Log("武器は外すことができません");
    }
}
