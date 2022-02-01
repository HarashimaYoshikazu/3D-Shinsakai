using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : Singleton<TextManager>
{
    [SerializeField, Tooltip("ホーム画面最初に表示するメッセージ")] 
    string _defaultMessage;

    [SerializeField, Tooltip("メッセージの親オブジェクトのパネルプレハブ")]
    GameObject _textCanvasPrehub;
    [SerializeField,Tooltip("メッセージを表示するTextObjectプレハブ")]
    Text _textPrehub = null;

    /// <summary>生成後のTextオブジェクト</summary>
    Text _message = null;

    /// <summary>生成後のCanvasオブジェクト</summary>
    GameObject _canvas = null;

    public void HomeDefault()
    {
        if (!_message && !_canvas)
        {
            _canvas = Instantiate(_textCanvasPrehub,this.transform);
            _message = Instantiate(_textPrehub,_canvas.transform);
        }
        _message.text = _defaultMessage;
    }

    /// <summary>
    /// メッセージオブジェクトのテキストを外部から変更する関数
    /// </summary>
    /// <param name="mes"></param>
    public void SetMessage(string mes)
    {
        _message.text = mes;
    }

    /// <summary>
    /// シーン移動する際にMessageを消す
    /// </summary>
    public void SetFalse()
    {
        if (_message)
        {
            Destroy(_canvas);
        }
    }
}
