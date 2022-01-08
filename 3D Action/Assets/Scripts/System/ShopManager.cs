using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] CardManager _cardManager;
    public void BuyCard(int value)
    {
        PlayerPalam.Instance.Goldfluctuation(value);
        int ran = Random.Range(0,_cardManager.AllCards.Length);
        CardManager.Instance.AddCard(_cardManager.AllCards[ran]);
    }
}
