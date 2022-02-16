using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUpCard : CardBase
{
    [SerializeField, Tooltip("追加するダメージ")]
    int _addDamage = 1;
    public override void Execute()
    {
        PlayerPalam.Instance.Attackfluctuation(_addDamage);
        base.Execute();
    }
}
