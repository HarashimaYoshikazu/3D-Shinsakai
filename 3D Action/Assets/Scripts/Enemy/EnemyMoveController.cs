using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{

    [SerializeField] Rigidbody _rb;
    /// <summary>プレイヤーの場所を保持する変数</summary>
    Vector3 _playerPosition = default;

    /// <summary>プレイヤーとの距離を保持しておく変数</summary>
    float _distance = default;

    [SerializeField,Tooltip("スピードの初期化値")]
    float _initialSpeed = 10f;

    /// <summary>エネミーを動かすスピード</summary>
    float _speed = default;

    [SerializeField,Tooltip("プレイヤーに向かって移動し始めるまでの距離")]
    float _enemyVisibleDistance;
    [SerializeField, Tooltip("攻撃が開始されるプレイヤーとの距離")]
    float _attackDistance;

    [SerializeField, Tooltip("このオブジェクトについているアニメーターコンポーネント")]
    Animator _animator = default;

    /// <summary>歩いているか判定するフラグ</summary>
    bool _isWalk = false;

    /// <summary>死んでいるか判定するフラグ</summary>
    bool _isDead = false;

    /// <summary>攻撃するかを判定するフラグ</summary>
    bool _isAttack = false;

    [SerializeField, Tooltip("このオブジェクトのEnemyクラス")]
    Enemy _enemy;

    [Header("Animatorのトリガー")]
    [SerializeField,Tooltip("攻撃アニメーションのブール名")]
    string _attackBool = "Attack";
    [SerializeField, Tooltip("走りアニメーションのトリガー名")]
    string _walkBool = "Walk";


    private void Start()
    {
        _speed = _initialSpeed;
    }

    private void FixedUpdate()
    {
        //プレイヤーの場所を取得
        _playerPosition = FPSPlayerMove.Instance.transform.position;
        //y軸を初期化
        _playerPosition.y = this.transform.position.y;
        //このオブジェクトとプレイヤーの距離
        _distance = Vector3.Distance(this.transform.position, FPSPlayerMove.Instance.transform.position);

        //移動アニメーションの設定
        if (_animator)
        {
            //ダッシュフラグをオンに
            _animator.SetBool(_walkBool, _isWalk);
            _animator.SetBool(_attackBool,_isAttack);
        }

        if (!_isDead)
        {
            if (_isWalk && !_isAttack)
            {
                MoveToPlayer();
            }

            StopFrontOfPlayer();
        }

    }

    /// <summary>
    /// 距離を計りプレイヤーのpositionまで移動する関数
    /// </summary>
    void MoveToPlayer()
    {
        //発覚範囲になったらプレイヤーに向かって動く
        if (_enemyVisibleDistance>_distance)
        {
            //プレイヤーの方向を取得
            Vector3 dir = _playerPosition - this.transform.position;
            dir.y = 0f;
            //移動
            _speed = _initialSpeed;
            if (dir != Vector3.zero) this.transform.forward = dir;
            _rb.velocity = dir.normalized * _speed * Time.deltaTime;
        }

    }


    /// <summary>
    /// 動きを止める関数
    /// </summary>
    void StopFrontOfPlayer()
    {
        
        if (_attackDistance >= _distance)
        {
            _isWalk = false;
            Debug.Log("こうげき");
            //動きを止める
            _rb.velocity = Vector3.zero;
            _speed = 0f;
            
            AttackMove();
        }
        else
        {
            _isWalk = true;
        }
        
    }

    /// <summary>
    /// 攻撃を開始する関数
    /// </summary>
    void AttackMove()
    {
        //プレイヤーにダメージを与える
        if (_enemy)
        {
            _enemy.Attack();
            Debug.Log($"HPは{PlayerPalam.Instance.HP}");
        }

        //攻撃中のフラグをONに
        _isAttack = true;
               
    }

    /// <summary>
    /// 死んだときに動きを止める関数
    /// </summary>
    public void DeadStop()
    {
        _isDead = true;
        _rb.velocity = Vector3.zero;
        _speed = 0f;
    }

    public void AttackFalse()
    {
        _isAttack = false;
    }
}
