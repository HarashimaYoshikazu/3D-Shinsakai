using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 現在の装備を管理するクラス
/// </summary>
public class GearManager : DDOLSingleton<GearManager>
{
    [SerializeField,Tooltip("頭装備のプレハブの配列")] HeadGear[] _headGearPrefubs = null;
    [SerializeField, Tooltip("体装備のプレハブの配列")] BodyGear[] _bodyGearPrefubs = null;
    [SerializeField, Tooltip("脚装備のプレハブの配列")] LegGear[] _legGearPrefubs = null;

    /// <summary>現在持っている装備が格納されている配列</summary>
    GearBase[] _gearInventry;
    public GearBase[] GearInventry => _gearInventry;

    [SerializeField,Tooltip("")] int _limitGearInventry = 10;

    HeadGear _currentHeadGear = null;
    BodyGear _currentBodyGear = null;
    LegGear _currentLegGear = null;


    void Start()
    {
        _gearInventry = new GearBase[_limitGearInventry];
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 現在の装備を変更する関数
    /// </summary>
    /// <param name="gear">GearBaseを継承したオブジェクト</param>
    public void EquipGear(GearBase gear)
    {
        if (gear is HeadGear)//型を見る
        {
            if (_currentHeadGear)
            {
                _currentHeadGear.OnTakeOff();//すでに装備を着ている場合は外す
            }
            _currentHeadGear = (HeadGear)gear;//gearをダウンキャスト

            _currentHeadGear.OnEquipment();//着た時の処理
        }
        else if (gear is BodyGear)
        {
            if (_currentBodyGear)
            {
                _currentBodyGear.OnTakeOff();
            }
            _currentBodyGear = (BodyGear)gear;
            _currentBodyGear.OnEquipment();
        }
        else if (gear is LegGear)
        {
            if (_currentLegGear)
            {
                _currentLegGear.OnTakeOff();
            }
            _currentLegGear = (LegGear)gear;
            _currentLegGear.OnEquipment();
        }
    }

    public void AddGear(GearBase gear)
    {
        if (_gearInventry.Length <= _limitGearInventry)
        {
            _gearInventry[_gearInventry.Length - 1] = gear;
        }
    }
    public void SellGear(GearBase gear)
    {

    }
}
