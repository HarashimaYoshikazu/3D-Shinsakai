using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPalam : Singleton<PlayerPalam>
{
    ///<summary>初期HP</summary>
    [SerializeField, Range(1, 100)] int _initialHP = 10;
    ///<summary>初期攻撃力</summary>
    [SerializeField, Range(1, 100)] int _initialAttack = 10;
    ///<summary>初期防御力</summary>
    [SerializeField, Range(1, 100)] int _initialDefence = 10;
    ///<summary>初期ゴールド</summary>
    [SerializeField, Range(1, 100)] int _initialGold = 10;
    ///<summary>初期スキルポイント</summary>
    [SerializeField, Range(1, 100)] int _initialSkillPoint = 10;

    ///<summary>現在のHP</summary>
    int _hp;
    ///<summary>現在の攻撃力</summary>
    int _at;
    ///<summary>現在の攻撃力</summary>
    int _def;
    ///<summary>現在のゴールド</summary>
    int _gold;
    ///<summary>現在のスキルポイント</summary>
    int _skillPoint;

    public int HP => _hp;
    public int Attack => _at;
    public int Defence => _def;
    public int Gold => _gold;
    public int SkillPoint => _skillPoint;

    protected override void OnAwake()
    {
        Debug.Log("HP初期化");
        _hp = _initialHP;
        _at = _initialAttack;
        _def = _initialDefence;
        _gold = _initialGold;
        _skillPoint = _initialSkillPoint;
    }

    public void HPfluctuation(int value)
    {
        _hp += value;
    }
    public void Attackfluctuation(int value)
    {
        _at += value;
    }
    public void Defencefluctuation(int value)
    {
        _def += value;
    }
    public void Goldfluctuation(int value)
    {
        _gold += value;
    }
    public void SkillPointfluctuation(int value)
    {
        _skillPoint += value;
    }
}
