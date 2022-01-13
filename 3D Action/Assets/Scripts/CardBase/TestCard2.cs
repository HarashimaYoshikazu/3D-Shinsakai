using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard2 : CardBase
{
    string ms2 = "testcard２です";

    public override void Execute()
    {
        PlayerHPBar.Instance.HPbarfluctuation(5);
    }
}
