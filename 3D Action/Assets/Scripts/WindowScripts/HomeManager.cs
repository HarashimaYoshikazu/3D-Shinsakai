using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : Singleton<HomeManager>
{
    // Start is called before the first frame update
    [SerializeField] GameObject _gearPanel ;
    [SerializeField] GameObject _gearInventryPanelPrefab = null;

    [SerializeField] GameObject _headPanel = null;
    [SerializeField] GameObject _bodyPanel = null;
    [SerializeField] GameObject _legPanel = null;
    void Start()
    {
        //テキストをデフフォルトに
        TextManager.Instance.HomeDefault();
        //HPリセット
        PlayerPalam.Instance.ResetHP();
        //装備パネルの生成
        if (_gearPanel && _gearInventryPanelPrefab)
        {
            _gearInventryPanelPrefab = Instantiate(_gearInventryPanelPrefab,_gearPanel.transform);
            _headPanel = Instantiate(_headPanel, _gearPanel.transform);
            _bodyPanel = Instantiate(_bodyPanel, _gearPanel.transform);
            _legPanel = Instantiate(_legPanel, _gearPanel.transform);
        }
    }

}
