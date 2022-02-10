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

    public HeadGear CurrentHeadGear { get => _currentHeadGear;}
    public LegGear CurrentLegGear { get => _currentLegGear;}
    public BodyGear CurrentBodyGear { get => _currentBodyGear; }

    [SerializeField,Tooltip("装備を持てる上限")] int _limitGearInventry = 10;

    HeadGear _currentHeadGear = null;
    BodyGear _currentBodyGear = null;
    LegGear _currentLegGear = null;

    HeadGear _lastHeadGear = null;
    BodyGear _lastBodyGear = null;
    LegGear _lastLegGear = null;


    protected override void OnAwake()
    {

        //試しに３つ追加
        AddGear(_headGearPrefubs[0]);
        AddGear(_headGearPrefubs[0]);
        AddGear(_bodyGearPrefubs[0]);
        AddGear(_legGearPrefubs[0]);
        Debug.Log($"インベントリのサイズ {_gearInventry.Count}");
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
                _gearInventry.Add(_headGearPrefubs[0]); //インベントリに装備を入れなおす※ここが原因
                Debug.Log($"インベントリのサイズ脱ぐ {_gearInventry.Count}");
            }
            _lastHeadGear = (HeadGear)gear;
            _currentHeadGear = (HeadGear)gear;//gearをダウンキャスト

            _currentHeadGear.OnEquipment();//着た時の処理
            //IDが一致する奴を削除            
            _gearInventry.RemoveAt(RemoveGear(gear)); //着ている最中はインベントリから外す
            Debug.Log($"追加される装備のIndex {gear.GearIndex}");
            Debug.Log($"インベントリのサイズ着る {_gearInventry.Count}");
        }
        else if (gear is BodyGear)
        {
            if (_currentBodyGear)
            {
                _currentBodyGear.OnTakeOff();
                _gearInventry.Add(_bodyGearPrefubs[0]);
            }
            _lastBodyGear = (BodyGear)gear;
            _currentBodyGear = (BodyGear)gear;
            _currentBodyGear.OnEquipment();

            _gearInventry.RemoveAt(RemoveGear(gear));
        }
        else if (gear is LegGear)
        {
            if (_currentLegGear)
            {
                _currentLegGear.OnTakeOff();
                _gearInventry.Add(_legGearPrefubs[0]);
            }
            _lastLegGear = (LegGear)gear;
            _currentLegGear = (LegGear)gear;
            _currentLegGear.OnEquipment();

            _gearInventry.RemoveAt(RemoveGear(gear));
        }
    }

    public void AddGear(GearBase gear)
    {
        if (_gearInventry.Count <= _limitGearInventry)
        {
            //インベントリに追加
            _gearInventry.Add(gear);
        }
    }
    public void SellGear(GearBase gear)
    {

    }

    public void InstansGear()
    {
        Debug.Log("インベントリのカウント"+_gearInventry.Count);
        if (_gearInventry.Count!=0)
        {
            for (int i = 0; i < _gearInventry.Count; ++i)
            {
                Instantiate(_gearInventry[i], HomeManager.Instance.GearInventryPanel.transform);
            }
        }


    }

    void DestroyGear()
    {
        foreach (var i in _gearInventry)
        {
            
        }
    }

    /// <summary>
    /// 装備IDが一致しているかを確認する関数
    /// </summary>
    /// <param name="gear"></param>
    /// <returns></returns>
    public int RemoveGear(GearBase gear)
    {
        for(int i = 0;i<_gearInventry.Count;++i)
        {
            if(_gearInventry[i].GeatID == gear.GeatID)
            {
                return i;
            }
        }
        return -1;
    }

}
