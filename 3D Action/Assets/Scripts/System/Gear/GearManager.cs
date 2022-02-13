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

    /// <summary>装備しているものは含まないサブの装備リスト</summary>
    List<GameObject> _inSceneGears = new List<GameObject>();

    /// <summary>現在装備中の頭装備</summary>
    GameObject _currentHeadGear;

    public List<GameObject> SubGears { get => _subGears;}
    public List<GameObject> InSceneGears { get => _inSceneGears;  }

    private void Start()
    {
        _gearInventry.Add( _GearPrefabs[0]);
        _gearInventry.Add(_GearPrefabs[0]);
    }

    List<GameObject> _tempList = new List<GameObject>();
    public void OnEquip(GameObject gear)
    {
        //装備するものをinSceneGearから削除
        _inSceneGears.Remove(gear);
        //※ここでSubGear（記憶用もRemoveする）

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
            int n = i.GetComponent<GearBase>().GearID;
            if (gear.GetComponent<GearBase>().GearID == n)
            {
                //装備中変数に装備するものを代入
                _currentHeadGear = i;
                break;
            }
        }

        
    }

    bool _isFirst = true;

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
            Instantiate(_currentHeadGear,HomeManager.Instance.HeadPanel.transform);
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
