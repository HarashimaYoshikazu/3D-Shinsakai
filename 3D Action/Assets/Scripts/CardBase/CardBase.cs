using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardBase : MonoBehaviour
{
    protected string _name;
    int _cardIndex;

    public int CardIndex { get => _cardIndex; set => _cardIndex = value; }
    public string Name { get => _name; set => _name = value; }

    public virtual void Execute()
    {
        Debug.Log("カードの効果実行してます");
    }
}
