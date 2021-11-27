using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] CardManager _cardManager;
    public void BuyCard(int value)
    {
        PlayerStateManager.Gold -= value;
        int ran = Random.Range(0,_cardManager.AllCards.Length);
        CardManager.InventriCards.Add(_cardManager.AllCards[ran]);
    }
}
