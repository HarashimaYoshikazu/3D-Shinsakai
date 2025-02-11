﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : DDOLSingleton<CardManager>
{
    //のちのちドロップ用とかイベント用とか色んな配列にする
    [SerializeField] GameObject[] _allCards;
    //今持っているカードが入っているゲームオブジェクト型のリスト
    List<GameObject> _inventriCards = new List<GameObject>();
    public List<GameObject> InventriCards => _inventriCards;
    public GameObject[] AllCards { get => _allCards;}

    protected override void OnAwake()
    {
        AddCard(_allCards[0]);
        AddCard(_allCards[1]);
    }

    public void AddCard(GameObject card)
    {
        //カードを追加
        _inventriCards.Add(card);
        //カードインデックスの設定
        card.GetComponent<CardBase>().CardIndex = this.InventriCards.Count - 1;
    }
    public void RemoveAtCard(int value)
    {
        _inventriCards.RemoveAt(value);
    }
}
