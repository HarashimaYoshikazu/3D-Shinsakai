using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardBase : MonoBehaviour
{
    [SerializeField] new string name;
    int _cardIndex;

    public int CardIndex { get => _cardIndex; set => _cardIndex = value; }

    public virtual void Execute()
    {
        Debug.Log("カードの効果実行してます");
    }
}
