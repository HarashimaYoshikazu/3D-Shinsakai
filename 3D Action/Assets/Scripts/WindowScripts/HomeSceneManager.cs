using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSceneManager : MonoBehaviour
{
    [SerializeField, Tooltip("ホーム画面最初に表示するメッセージ")] 
    string _defaultMessage;

    [SerializeField,Tooltip("メッセージを表示するTextObject")]
    Text _text;
    void Start()
    {
        HomeDefault();
        //現在のStateをHomeに変更
        GameManager.Instance.StateChange(State.Home);
        //HPリセット
        PlayerPalam.Instance.ResetHP();
    }

    public void HomeDefault()
    {
        _text.text = _defaultMessage;
    }
}
