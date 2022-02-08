using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : DDOLSingleton<GearManager>
{
    [SerializeField,Tooltip("頭装備のプレハブの配列")] HeadGear[] _headGearPrefubs = null;
    [SerializeField, Tooltip("体装備のプレハブの配列")] BodyGear[] _bodyGearPrefubs = null;
    [SerializeField, Tooltip("脚装備のプレハブの配列")] LegGear[] _legGearPrefubs = null;

    /// <summary>現在持っている装備が格納されている配列</summary>
    GearBase[] _gearInventry;
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
        if (gear is HeadGear)
        {
            _currentHeadGear = (HeadGear)gear;
        }
        else if (gear is BodyGear)
        {
            _currentBodyGear = (BodyGear)gear;
        }
        else if (gear is LegGear)
        {
            _currentLegGear = (LegGear)gear;
        }
    }

    public void AddGear(GearBase gear)
    {
        if (_gearInventry.Length <= _limitGearInventry)
        {
            _gearInventry[_gearInventry.Length - 1] = gear;
        }
    }
}
