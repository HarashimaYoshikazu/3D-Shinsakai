using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : DDOLSingleton<WeaponManager>
{
    [SerializeField, Tooltip("銃のモデルプレハブ")]
    GameObject[] _gunPrefabs;

    [SerializeField, Tooltip("銃のアイコンのプレハブ")]
    GameObject[] _gunIconPrefabs;

    /// <summary>現在の銃のアニメーターコンポーネント </summary>
    Animator _currentGunAnimator;
    public Animator CurrentGunAnimator => _currentGunAnimator;


    List<GameObject> _weaponInventry = new List<GameObject>();


    private void Start()
    {
        //アイコンオブジェクトを追加
        _weaponInventry.Add(_gunIconPrefabs[0]);
    }

    public void InstanceWeaponObject(Transform gunCameraTransform)
    {
        //武器のIDをインデックスとして使用しプレハブを生成
        int index =  _currentGunAnimator.gameObject.GetComponent<GearBase>().GearID;
        if (_gunIconPrefabs.Length-1 >= index)
        {
            var go = Instantiate(_gunPrefabs[index], gunCameraTransform);
            _currentGunAnimator = go.GetComponent<Animator>();
        }
        else
        {
            //ギアIDが不正な値の場合はピストルを装備
            var go = Instantiate(_gunPrefabs[0], gunCameraTransform);
            _currentGunAnimator = go.GetComponent<Animator>();
        }
        
        
    }

    public void InstanceWeaponIcon()
    {
        foreach(var i in _gunIconPrefabs)
        {
            Instantiate(i,HomeManager.Instance.WeaponInventryPanel.transform);
        }
    }
}
