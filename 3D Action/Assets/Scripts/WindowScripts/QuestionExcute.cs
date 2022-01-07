using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionExcute : MonoBehaviour
{
    GameObject _playingcard;
    CardController _cardController;
    [SerializeField, Header("UI関係"), Tooltip("UIパネル")] 
    GameObject _UIPanel;
    [SerializeField, Tooltip("カード実行時の質問パネル")]
    GameObject _questionPanel;
    [SerializeField, Tooltip("インベントリパネル")]
    GameObject _inventriPanel;
    [SerializeField, Tooltip("質問のYesボタン")]
    GameObject _yes;
    [SerializeField, Tooltip("質問のNoボタン")]
    GameObject _no;
    [SerializeField, Tooltip("ゲームマネージャー")]
    PanelController _gameManager;
    public void Yes()
    {
        _playingcard = GameObject.FindGameObjectWithTag("PlayingCard");
        CardBase cb = _playingcard.gameObject.GetComponent<CardBase>();
        cb.Execute();
        _questionPanel.SetActive(false);
        _gameManager.PanelOf();
        CardManager.InventriCards.RemoveAt(cb.CardIndex);
        Destroy(_playingcard);
        _yes.SetActive(false);
        _no.SetActive(false);
    }

    public void No()
    {
        //今使用されようとしているカードを見つけてきてそれを動かせないようにする
        _playingcard = GameObject.FindGameObjectWithTag("PlayingCard");
        _cardController = _playingcard.GetComponent<CardController>();
        _cardController.enabled = true;
        //切ったらもとに戻してあげる
        _playingcard.gameObject.tag = "CardTag";
        //questionPanelとYesNoを見えなくする（次も使うから）
        _no.SetActive(false);
        _yes.SetActive(false);
        _questionPanel.SetActive(false);
        //結局使われなかったカードをインベントリに戻す
        _playingcard.transform.parent = _inventriPanel.transform;
    }
}
