using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject _cardUIPanel;
    Text _cardTypeText;
    Text _cardInfoText;
    [SerializeField, Tooltip("カードのタイプと距離を記載する")] string _cardType;
    [SerializeField, Tooltip("カードの説明")] string _cardInfo;
    [SerializeField] Vector2 _offset;
    GameManager gm;
    void Start()
    {
         gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        gm.InfoOnOf(true);
        _cardUIPanel = GameObject.FindGameObjectWithTag("CardInfoTag");
        _cardTypeText = GameObject.FindGameObjectWithTag("CardNameTag").GetComponent<Text>();
        _cardInfoText = GameObject.FindGameObjectWithTag("CardKoukaTag").GetComponent<Text>();
        _cardUIPanel.transform.position = eventData.position + _offset;
        _cardTypeText.text = _cardType;
        _cardInfoText.text = _cardInfo;


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gm.InfoOnOf(false);
    }
}
