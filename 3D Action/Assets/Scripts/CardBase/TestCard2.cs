using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard2 : CardBase
{
    [SerializeField] string _uniqeName;
    string ms2 = "testcard２です";
    private void Awake()
    {
        _name = _uniqeName;
    }
    public override void Execute()
    {
        PlayerHPBar.Instance.HPbarfluctuation(5);
    }
}
