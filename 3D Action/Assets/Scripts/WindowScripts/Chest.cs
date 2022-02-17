using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField,Tooltip("宝箱に入っているカードプレハブ")]
    GameObject _cardInChest;

    [SerializeField,Tooltip("宝箱に入っている装備プレハブ")]
    GameObject _gearInChest;

    [SerializeField, Tooltip("宝箱に入っているお金")]
    int _goldInChest;
    public void OpenChest()
    {
        if(_cardInChest)
        {
            CardManager.Instance.AddCard(_cardInChest);
        }
        if(_gearInChest)
        {
            GearManager.Instance.AddGear(_gearInChest);
        }
        if(_goldInChest >0)
        {
            PlayerPalam.Instance.Goldfluctuation(_goldInChest);
        }
        var cardname = _cardInChest.GetComponent<CardBase>().Name;
        var gearname = _gearInChest.GetComponent<GearBase>().GearName;
        InBattleSceneManager.Instance.SetItemText($"＋{cardname}\n＋{_goldInChest}ゴールド\n＋{gearname}");
    }
}
