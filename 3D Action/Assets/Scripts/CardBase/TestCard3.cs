using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard3 : CardBase
{
    [SerializeField]  string _uniqeName;
    [SerializeField] float Intervalfluctuation = -0.5f;
    private void Awake()
    {
        _name = _uniqeName;
    }
    public override void Execute()
    {
        FPSShoot.FireIntervalfluctuation(Intervalfluctuation);
    }
}
