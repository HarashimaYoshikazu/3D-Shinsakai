using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 現在の装備を管理するクラス
/// </summary>
public class GearManager : DDOLSingleton<GearManager>
{
    [SerializeField,Tooltip("頭装備のプレハブの配列")]
    HeadGear[] _headGearPrefubs = null;
    [SerializeField, Tooltip("体装備のプレハブの配列")]
    BodyGear[] _bodyGearPrefubs = null;
    [SerializeField, Tooltip("脚装備のプレハブの配列")]
    LegGear[] _legGearPrefubs = null;

    /// <summary>現在持っている装備が格納されている配列</summary>
    List<GearBase> _gearInventry = new List<GearBase>();
    public List<GearBase> GearInventry => _gearInventry;

    [SerializeField,Tooltip("装備を持てる上限")] int _limitGearInventry = 10;

    HeadGear _currentHeadGear = null;
    BodyGear _currentBodyGear = null;
    LegGear _currentLegGear = null;


    protected override void OnAwake()
    {

        //試しに３つ追加
        AddGear(_headGearPrefubs[0]);
        AddGear(_bodyGearPrefubs[0]);
        AddGear(_legGearPrefubs[0]);
        Debug.Log(_headGearPrefubs[0]);
        Debug.Log($"インベントリのサイズ {_gearInventry.Count}");
    }

    private void OnEnable()
    {
        InstansGear();
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
                _gearInventry.Add(_currentHeadGear); //インベントリに装備を入れなおす
            }
            _currentHeadGear = (HeadGear)gear;//gearをダウンキャスト

            _currentHeadGear.OnEquipment();//着た時の処理
            _gearInventry.Remove(_currentHeadGear); //着ている最中はインベントリから外す
        }
        else if (gear is BodyGear)
        {
            if (_currentBodyGear)
            {
                _currentBodyGear.OnTakeOff();
                _gearInventry.Add(_currentBodyGear);
            }
            _currentBodyGear = (BodyGear)gear;
            _currentBodyGear.OnEquipment();
            _gearInventry.Remove(_currentBodyGear);
        }
        else if (gear is LegGear)
        {
            if (_currentLegGear)
            {
                _currentLegGear.OnTakeOff();
                _gearInventry.Add(_currentLegGear);
            }
            _currentLegGear = (LegGear)gear;
            _currentLegGear.OnEquipment();
            _gearInventry.Remove(_currentLegGear);
        }
    }

    public void AddGear(GearBase gear)
    {
        if (_gearInventry.Count <= _limitGearInventry)
        {
            _gearInventry.Add(gear);
        }
    }
    public void SellGear(GearBase gear)
    {

    }

    void InstansGear()
    {
        if (!isFirst)
        {
            DestroyAllGear();
            isFirst = true;
        }

        for (int i = 0;i<_gearInventry.Count;++i)
        {
            _gearInventry[i] = Instantiate(_gearInventry[i], HomeManager.Instance.GearInventryPanel.transform);
        }
    }

    bool isFirst = false;
    void DestroyAllGear()
    {
        foreach (var gear in _gearInventry)
        {
            Debug.Log("うんこ");
            Destroy(gear);
        }
    }
}
