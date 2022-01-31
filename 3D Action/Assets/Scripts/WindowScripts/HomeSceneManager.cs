using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSceneManager : Singleton<HomeSceneManager>
{
    [SerializeField, Tooltip("ホーム画面最初に表示するメッセージ")] 
    string _defaultMessage;

    [SerializeField, Tooltip("メッセージの親オブジェクトのパネルプレハブ")]
    GameObject _textPanelPrehub;
    [SerializeField,Tooltip("メッセージを表示するTextObjectプレハブ")]
    Text _textPrehub = null;

    /// <summary>生成後のTextオブジェクト</summary>
    Text _message;
    void Start()
    {
        HomeDefault();
        //HPリセット
        PlayerPalam.Instance.ResetHP();
    }

    public void HomeDefault()
    {
        if (!_message)
        {
            var panel = Instantiate(_textPanelPrehub,this.transform);
            _message = Instantiate(_textPrehub,panel.transform);
        }
        _textPrehub.text = _defaultMessage;
    }

    public void SetMessage(string mes)
    {
        _message.text = mes;
    }
}
