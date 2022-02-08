using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : CardBase
{
    public override void Execute()
    {
        PlayerPalam.Instance.HPfluctuation(5);
        int index = CardManager.Instance.InventriCards.IndexOf(this.gameObject);
        Debug.Log($"使ったカードのインデックスは{index}");
        base.Execute();
        Debug.Log("HPは" + PlayerPalam.Instance.HP);
    }
}
