using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    //のちのちドロップ用とかイベント用とか色んな配列にする
    [SerializeField] GameObject[] _allCards;
    static List<GameObject> inventriCards = new List<GameObject>(); public static List<GameObject> InventriCards { get => inventriCards; set => inventriCards = value; }
    public GameObject[] AllCards { get => _allCards; set => _allCards = value; }

    private void Start()
    {
        inventriCards.Add(AllCards[0]);
        CardBase cb = inventriCards[inventriCards.Count-1].gameObject.GetComponent<CardBase>();
        cb.CardIndex = inventriCards.Count-1;
        Debug.Log(cb.CardIndex);
        inventriCards.Add(AllCards[1]);
        CardBase cb2 = inventriCards[inventriCards.Count - 1].gameObject.GetComponent<CardBase>();
        cb2.CardIndex = inventriCards.Count - 1;
        Debug.Log(cb2.CardIndex);
    }
    public void UseCard()
    {
        Debug.Log(inventriCards[0]);
    }
}
