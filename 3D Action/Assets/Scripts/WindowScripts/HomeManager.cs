using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : Singleton<HomeManager>
{
    [SerializeField,Tooltip("装備関係の全ての親パネル")]
    GameObject _gearPanel ;

    [SerializeField,Tooltip("持っている装備の親オブジェクトとなるパネル")]
    GameObject _gearInventryPanel = null;
    public GameObject GearInventryPanel => _gearInventryPanel;

    [SerializeField,Tooltip("頭装備")] GameObject _headPanel = null;
    public GameObject HeadPanel => _headPanel;
    [SerializeField, Tooltip("体装備")] GameObject _bodyPanel = null;
    public GameObject BodyPanel => _bodyPanel;
    [SerializeField, Tooltip("脚装備")] GameObject _legPanel = null;
    public GameObject LegPanel => _legPanel;
    void Start()
    {
        //テキストをデフフォルトに
        TextManager.Instance.HomeDefault();
        //HPリセット
        PlayerPalam.Instance.ResetHP();
        //装備パネルの生成
        if (_gearPanel && _gearInventryPanel)
        {
            _gearInventryPanel = Instantiate(_gearInventryPanel,_gearPanel.transform);
            _headPanel = Instantiate(_headPanel, _gearPanel.transform);
            _bodyPanel = Instantiate(_bodyPanel, _gearPanel.transform);
            _legPanel = Instantiate(_legPanel, _gearPanel.transform);
        }
    }

}
