using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    [SerializeField, Tooltip("攻撃でプレイヤーに与えるダメージ")]
    int _attackDamage = 2;
    [SerializeField, Tooltip("プレイヤーにダメージを与える間隔")]
    float _attackInterval = 2f;
    /// <summary>攻撃間隔を計るタイマー</summary>
    float _timer = 0f;
    [SerializeField, Tooltip("アニメーターコンポーネント")]
    Animator _animator;

    [SerializeField, Tooltip("EnemyMoveクラス")]
    EnemyMoveController _enemyMoveController;

    [SerializeField, Tooltip("死亡アニメーションのトリガー名")]
    string _deathTrigger = "Death";

    void Start()
    {
        //HP初期化
        _life = _initialLife;

        //ドロップするカードを全カードからランダムに決める
        if (CardManager.Instance)
        {
            int ran = Random.Range(0, CardManager.Instance.AllCards.Length);
            _dropCard = CardManager.Instance.AllCards[ran];
        }
        
       
    }
    private void Update()
    {
        _timer += Time.deltaTime;
    }

    public void Damage(int damage)
    {
        _life -= damage;
        if (_life < 1)
        {
            Dead();
            _enemyMoveController.DeadStop();
            Destroy(gameObject,5f);
            //レイヤー変える
            this.gameObject.layer = default;
        }
    }

    void Dead()
    {
        //敵を倒したとき用の関数を呼ぶ
        EnemyManager.Instance.OnDeadEnemy(this.gameObject);

        //インベントリにランダムなカードを追加
        CardManager.Instance.AddCard(_dropCard);
        InBattleSceneManager.Instance.GetCardCount();

        //お金、経験値を追加
        PlayerPalam.Instance.Goldfluctuation(_getGold) ;
        InBattleSceneManager.Instance.GetGoldCount(_getGold);
        PlayerPalam.Instance.SkillPointfluctuation(_getSkillPoint);

        //死亡時アニメーション
        _animator.SetTrigger(_deathTrigger);

        var cardname = _dropCard.GetComponent<CardBase>().Name;
        //手に入れたアイテムをパネルに表示
        InBattleSceneManager.Instance.SetItemText($"＋{cardname}\n＋{_getGold}ゴールド\n＋{_getSkillPoint}ポイント");
    }

    /// <summary>
    /// 一定間隔ごとにプレイヤーのＨＰを減らす関数
    /// </summary>
    public void Attack()
    {        
        if (_attackInterval<_timer)
        {
            PlayerPalam.Instance.HPfluctuation(-(_attackDamage));
            _timer = 0;
        }
    }
}
