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
        inventriCards.Add(AllCards[1]);
    }
    public void UseCard()
    {
        Debug.Log(inventriCards[0]);
    }
}
