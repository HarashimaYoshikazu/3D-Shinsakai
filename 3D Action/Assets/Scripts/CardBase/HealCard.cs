using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : CardBase
{
    string ms2 = "testcard２です";
    public override void Execute()
    {
        PlayerPalam.Instance.HPfluctuation(5);
        base.Execute();
    }
}
