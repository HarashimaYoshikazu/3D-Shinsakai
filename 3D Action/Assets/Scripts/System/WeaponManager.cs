using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : DDOLSingleton<WeaponManager>
{
    [SerializeField, Tooltip("銃のモデルプレハブ")]
    GameObject[] _gunPrefabs;

    [SerializeField, Tooltip("銃のアイコンのプレハブ")]
    GameObject[] _gunIconPrefabs;

    /// <summary>現在の銃のアイコンオブジェクト、これを変更することで生成を切り替える </summary>
    GameObject _currentGun;
    public GameObject CurrentGun => _currentGun;

    List<GameObject> _weaponIconInventry = new List<GameObject>();


    private void Start()
    {
        _currentGun = _gunIconPrefabs[0];
        //アイコンオブジェクトを追加
        _weaponIconInventry.Add(_gunIconPrefabs[0]);
    }


    /// <summary>
    /// 装備した際に装備中武器変数の中身を変える
    /// </summary>
    public void Equip(GameObject go)
    {
        foreach (var i in _gunIconPrefabs)
        {
            int gearID = i.GetComponent<GearBase>().GearID;
            //IDが一致したプレハブを装備中武器変数に代入
            if (gearID == go.GetComponent<GearBase>().GearID)
            {
                _currentGun = i;
                break;
            }
        }
    }
    /// <summary>
    /// バトルシーン用のインスタンス関数
    /// </summary>
    /// <param name="gunCameraTransform"></param>
    public void InstanceWeaponObject(Transform gunCameraTransform)
    {
        //GearBaseのIDを添え字として使用
        int index = _currentGun.GetComponent<GearBase>().GearID;
        //武器用カメラの子オブジェクトとして武器を生成
        Instantiate(_gunPrefabs[index],InBattleSceneManager.Instance.GunCamera.transform);
    }

    /// <summary>
    /// ホーム用のインスタンス関数
    /// </summary>
    public void InstanceWeaponIcon()
    {

    }

    public Animator CurrentAnimator()
    {
        return _currentGun.GetComponent<Animator>();
    }
}
