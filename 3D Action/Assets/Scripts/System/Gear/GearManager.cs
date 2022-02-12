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
    List<GameObject> _gearInventry = new List<GameObject>();
    List<GameObject> _inSceneGears = new List<GameObject>();

    public List<GameObject> InSceneGears { get => _inSceneGears;}

    private void Start()
    {
        _gearInventry.Add( _GearPrefabs[0]);
    }
    public void InstansGear()
    {
        if (_inSceneGears.Count ==0)
        {
            foreach (var i in _gearInventry)
            {
                _inSceneGears.Add(Instantiate(i, HomeManager.Instance.GearInventryPanel.transform));
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

    public void SetFalseGear()
    {
        foreach (var i in _inSceneGears)
        {
            i.gameObject.SetActive(false);
        }
    }

}
