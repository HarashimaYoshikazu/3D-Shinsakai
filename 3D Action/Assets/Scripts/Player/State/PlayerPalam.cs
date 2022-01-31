using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPalam : DDOLSingleton<PlayerPalam>
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

    ///<summary>現在のレベル</summary>
    int _level;
    ///<summary>現在のHP</summary>
    int _hp ;
    ///<summary>現在の攻撃力</summary>
    int _at;
    ///<summary>現在の攻撃力</summary>
    int _def;
    ///<summary>現在のゴールド</summary>
    int _gold ;
    ///<summary>現在のスキルポイント</summary>
    int _skillPoint = 0;

    public int HP => _hp;
    public int Attack => _at;
    public int Defence => _def;
    public int Gold => _gold;
    public int SkillPoint => _skillPoint;

    protected override void OnAwake()
    {
        _hp = _initialHP;
        _at = _initialAttack;
        _def = _initialDefence;
        _gold = _initialGold;
        _skillPoint = _initialSkillPoint;
    }

    public void HPfluctuation(int value)
    {
        if (_hp + value <= 0)
        {
            _hp = 0;
        }
        else
        {
            _hp += value;
        }
        
        if (PlayerHPBar.Instance)
        {
            PlayerHPBar.Instance.HPbarfluctuation();
        }

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

    public void ResetHP()
    {
        _hp = _initialHP;
    }
}
