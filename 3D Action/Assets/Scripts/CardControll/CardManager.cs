using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaedManager : MonoBehaviour
{
    [SerializeField] GameObject _card1;
    [SerializeField] GameObject _card2;
    static GameObject[] cards  = new GameObject[10];    public static GameObject[] Cards { get => cards; set => cards = value; }

    private void Start()
    {
        cards[0] = _card1;
        cards[1] = _card2;
    }
    void UseCard()
    {
        Debug.Log(cards[0]);
    }
}
