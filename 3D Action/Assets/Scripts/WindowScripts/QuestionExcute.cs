using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionExcute : MonoBehaviour
{

    GameObject _playingcard;
    CardController _cardController;
    [SerializeField] GameObject _questionPanel;
    [SerializeField] GameObject _inventriPanel;
    [SerializeField] GameObject _yes;
    [SerializeField] GameObject _no;
    public void Yes()
    {

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
