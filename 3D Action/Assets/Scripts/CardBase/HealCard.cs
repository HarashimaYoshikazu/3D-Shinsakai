using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : CardBase
{
    public override void Execute()
    {
        PlayerPalam.Instance.HPfluctuation(5);
        base.Execute();
        Debug.Log("HPは" + PlayerPalam.Instance.HP);
    }
}
