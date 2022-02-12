using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 現在の装備を管理するクラス
/// </summary>
public class GearManager : DDOLSingleton<GearManager>
{
    [SerializeField, Tooltip("頭装備のプレハブ")]
    GameObject[] _headGearPrefabs;

    List<GameObject> _subHeadGears = new List<GameObject>();

    /// <summary>現在の頭装備</summary>
    GameObject _currentHeadGear = null;
    public GameObject CurrentHeadGear { get => _currentHeadGear; }

    private void Start()
    {
        AddGear(_headGearPrefabs[0]);
    }
    void AddGear(GameObject gear)
    {
        if (gear.TryGetComponent(out HeadGear headGear))
        {
            _subHeadGears.Add(gear);
        }
        else if (gear.TryGetComponent(out BodyGear bodyGear))
        {

        }
        else if (gear.TryGetComponent(out LegGear legGear))
        {

        }
    }

    /// <summary>
    /// 選んだ控え装備と現在装備中のものを交換する関数
    /// </summary>
    /// <param name="gear">着る装備</param>
    public void EquipGear(GameObject gear)
    {
        if (gear.TryGetComponent(out HeadGear headGear))
        {

            RemoveGearFromList(headGear.GearID);//控えリストから着たい装備を消す

            _subHeadGears.Add(_currentHeadGear);//現在装備しているものを控えリストに追加

            _currentHeadGear = gear;//装備中変数に装備したいものを代入
        }
        else if (gear.TryGetComponent(out BodyGear bodyGear))
        {

        }
        else if (gear.TryGetComponent(out LegGear legGear))
        {

        }
    }

    /// <summary>
    /// ただ単に装備中のものを脱ぐ関数
    /// </summary>
    /// <param name="gear">脱ぐ装備</param>
    public void TakeOffGear(GameObject gear)
    {
        if (gear.TryGetComponent(out HeadGear headGear))
        {
            //※Clearしてから入れなおす
            _tempList.Clear();
            foreach (var i in _subHeadGears)
            {
                if (i)
                {
                    _tempList.Add(i);
                }

            }
            _subHeadGears.Clear();
            foreach (var i in _tempList)
            {
                if (i)
                {
                    _subHeadGears.Add(i);
                }

            }
            //引数で持ってきたGameObjectを控えリストに追加
            _subHeadGears.Add(gear);
            _currentHeadGear = null;
        }
        else if (gear.TryGetComponent(out BodyGear bodyGear))
        {

        }
        else if (gear.TryGetComponent(out LegGear legGear))
        {

        }
    }

    List<GameObject> _tempList = new List<GameObject>();
    void RemoveGearFromList(int id)
    {
        _tempList.Clear();
        foreach (var i in _subHeadGears)
        {
            _tempList.Add(i);
        }

        foreach (var i in _tempList)
        {
            if (!i)
            {
                continue;
            }
            else if (i.GetComponent<HeadGear>().GearID == id)
            {
                _subHeadGears.Remove(i);
            }
        }

    }

    List<GameObject> _sceneGearList = new List<GameObject>();
    public void InstansGear()
    {　　

        if (_sceneGearList.Count != 0)
        {
            foreach (var i in _sceneGearList)
            {
                i.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (var i in _subHeadGears)
            {
                _sceneGearList.Add(Instantiate(i, HomeManager.Instance.GearInventryPanel.transform));
            }
        }

    }

    public void SetFalseSceneGear()
    {
        foreach (var i in _sceneGearList)
        {
            i.gameObject.SetActive(false);
        }
    }

    public void ResetList()
    {
        _sceneGearList.Clear();
    }

}
