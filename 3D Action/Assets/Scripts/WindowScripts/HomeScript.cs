using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScript : MonoBehaviour
{
    [SerializeField, Tooltip("ホーム画面最初に表示するメッセージ")] 
    string _defaultMessage;

    [SerializeField,Tooltip("メッセージを表示するTextObject")]
    Text _text;
    void Start()
    {
        HomeDefault();
    }

    public void HomeDefault()
    {
        _text.text = _defaultMessage;
    }
}
