using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 現在の装備を管理するクラス
/// </summary>
public class GearManager : DDOLSingleton<GearManager>
{
    [SerializeField, Tooltip("プレハブ")]
    GameObject[] _GearPrefabs;

    /// <summary>装備しているものも含む全ての装備リスト</summary>
    List<GameObject> _gearInventry = new List<GameObject>();

    /// <summary>装備しているものは含まないサブの装備リスト</summary>
    List<GameObject> _subGears = new List<GameObject>();
    public List<GameObject> SubGears { get => _subGears; }

    /// <summary>？装備しているものは含まないInstanc用のリスト</summary>
    List<GameObject> _inSceneGears = new List<GameObject>();
    public List<GameObject> InSceneGears { get => _inSceneGears; }

    /// <summary>現在装備中の頭装備</summary>
    GameObject _currentHeadGear;
    public GameObject CurrentHeadGear => _currentHeadGear;

    GameObject _currentBodyGear;
    public GameObject CurrentBodyGear => _currentBodyGear;

    GameObject _currentLegGear;
    public GameObject CurrentLegGear => _currentLegGear;




    private void Start()
    {
        _gearInventry.Add( _GearPrefabs[0]);
        _gearInventry.Add(_GearPrefabs[0]);
        _gearInventry.Add(_GearPrefabs[1]);
        _gearInventry.Add(_GearPrefabs[2]);
    }

    /// <summary>バグ回避用の一時リスト</summary>
    List<GameObject> _tempList = new List<GameObject>();
    public void OnEquip(GameObject gear)
    {
        //装備するものをinSceneGearから削除
        _inSceneGears.Remove(gear);
        //SubGear（記憶用もRemoveする）
        //エラー回避のためにTempListも使用

        foreach (var i in _subGears)
        {
            _tempList.Add(i);
        }

        foreach(var i in _tempList)
        {
            int n = i.GetComponent<GearBase>().GearID;
            if (gear.GetComponent<GearBase>().GearID == n)
            {
                Debug.Log(i);
                _subGears.Remove(i);
                break;
            }
        }
        _tempList.Clear();

        foreach(var i in _GearPrefabs)
        {
            GearBase gb = gear.GetComponent<GearBase>();
            int n = i.GetComponent<GearBase>().GearID;
            if (gb.GearID == n)
            {
                //装備中変数に装備するものを型推論して代入
                if (gb is HeadGear)
                {
                    _currentHeadGear = i;
                }
                else if (gb is BodyGear)
                {
                    _currentBodyGear = i;
                }
                else if (gb is LegGear)
                {
                    _currentLegGear = i;
                }
                
                break;
            }
        }
        
    }

    public void OnTakeOff(GearBase gb)
    {
        int n;

        //装備しなくなったものをSubGearに戻す
        foreach(var i in _GearPrefabs)
        {
            n = _currentHeadGear.GetComponent<GearBase>().GearID;
            Debug.Log(n);
            if(n ==i.GetComponent<GearBase>().GearID)
            {
                _subGears.Add(i);
            }
        }
        if (gb is HeadGear)
        {
            _currentHeadGear = null;
        }
        else if (gb is BodyGear)
        {
            _currentBodyGear = null;
        }
        else if (gb is LegGear)
        {
            _currentLegGear = null;
        }
        
    }


    /// <summary>
    /// まだシーン上にインスタンスされてない場合は生成、されている場合はSetActiveをTrueに
    /// </summary>
    public void InstansGear()
    {
        if (_subGears.Count ==0 && !_currentHeadGear)
        {
            foreach (var i in _gearInventry)
            {             
                _subGears.Add(i); //記憶用
                _inSceneGears.Add(Instantiate(i, HomeManager.Instance.GearInventryPanel.transform)) ;
            }
            foreach (var i in _inSceneGears)
            {
                i.gameObject.SetActive(true);
            }
        }
        else if (_subGears.Count !=0 && _inSceneGears.Count ==0)
        {
            foreach (var i in _subGears)
            {                
                _inSceneGears.Add(Instantiate(i, HomeManager.Instance.GearInventryPanel.transform));
            }
            foreach (var i in _inSceneGears)
            {
                i.gameObject.SetActive(true);
            }
            if (_currentHeadGear)
            {
                Instantiate(_currentHeadGear, HomeManager.Instance.HeadPanel.transform);
            }
            
        }
        else
        {
            foreach (var i in _inSceneGears)
            {
                i.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// パネルが閉じられるときSetActiveをFalseに
    /// </summary>
    public void SetFalseGear()
    {
        foreach (var i in _inSceneGears)
        {
            i.gameObject.SetActive(false);
        }
    }

    public void OnSceneChange()
    {
        
    }

}
