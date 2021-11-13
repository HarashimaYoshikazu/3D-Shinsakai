using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] GameObject _card1 = null;
    [SerializeField] GameObject _card2 = null;
    static List<GameObject> cards = new List<GameObject>();   public static List<GameObject> Cards { get => cards; set => cards = value; }

    private void Start()
    {
        cards.Add(_card1);
        cards.Add(_card2);
    }
    public void UseCard()
    {
        Debug.Log(cards[0]);
    }
}
