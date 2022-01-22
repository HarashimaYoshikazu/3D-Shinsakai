using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("エネミーの情報")]

    [SerializeField, Range(1, 30), Tooltip("エネミーHP")]
    int _initialLife = 3;

    int _life;

    [SerializeField, Tooltip("ドロップするゴールド")] 
    int _getGold = 5;
    [SerializeField, Tooltip("獲得するスキルポイント")]
    int _getSkillPoint = 2;
    /// <summary>倒すと獲得できるカード</summary>
    GameObject _dropCard;

    void Start()
    {
        //Debug.Log($"カード：{CardManager.Instance.InventriCards[CardManager.Instance.InventriCards.Count - 1]}");
        Debug.Log($"お金：{PlayerPalam.Instance.Gold}");
      Debug.Log($"スキルポイント：{PlayerPalam.Instance.SkillPoint}");
        //HP初期化
        _life = _initialLife;

        CardManager cm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CardManager>();
        //ドロップするカードを全カードからランダムに決める
        int ran = Random.Range(0, cm.AllCards.Length);
        _dropCard = cm.AllCards[ran];
    }

    public void Damage(int damage)
    {
        _life -= damage;
        if (_life < 1)
        {
            Destroy(gameObject);
            Dead();
        }
    }

    void Dead()
    {
        
        //インベントリにランダムなカードを追加
        CardManager.Instance.AddCard(_dropCard);

        //お金、経験値を追加
        PlayerPalam.Instance.Goldfluctuation(_getGold) ;
        PlayerPalam.Instance.SkillPointfluctuation(_getSkillPoint);
        //死ぬアニメーションを再生 
        Debug.Log("しんだ");
        Debug.Log($"カード：{CardManager.Instance.InventriCards[CardManager.Instance.InventriCards.Count - 1]}");
        Debug.Log($"お金：{PlayerPalam.Instance.Gold}");
        Debug.Log($"スキルポイント：{PlayerPalam.Instance.SkillPoint}");
    }
}
