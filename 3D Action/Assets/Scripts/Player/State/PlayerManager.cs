using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーのHP")] int _hp = 20;
    public int HP { get => _hp;}
    [SerializeField,Tooltip("プレイヤーの攻撃力")] int _attack = 20;
    public int Attack { get => _attack; }
    [SerializeField, Tooltip("プレイヤーのお金")] int _gold = 20;
    public int Gold { get => _gold; }
    [SerializeField, Tooltip("プレイヤーのスキルポイント")] int _skillPoint = 20;
    public int SkillPoint { get => _skillPoint; }
    
    void HPFluctuation(int value)
    {
        _hp += value;
    }
    void AttackFluctuation(int value)
    {
        _attack += value;
    }
    void GoldFluctuation(int value)
    {
        _gold += value;
    }
    void SkillPointFluctuation(int value)
    {
        _skillPoint += value;
    }
}
