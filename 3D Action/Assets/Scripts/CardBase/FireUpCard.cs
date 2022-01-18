using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUpCard : CardBase
{
    [SerializeField] float Intervalfluctuation = -0.5f;

    public override void Execute()
    {
        FPSShoot.FireIntervalfluctuation(Intervalfluctuation);
        base.Execute();
    }
}
