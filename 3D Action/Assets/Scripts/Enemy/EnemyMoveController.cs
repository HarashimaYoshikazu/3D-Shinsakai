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

    /// <summary>動くか攻撃するかを判定するフラグ</summary>
    bool _isRun = false;

    /// <summary>動くか攻撃するかを判定するフラグ</summary>
    bool _isDead = false;

    [SerializeField, Tooltip("このオブジェクトのEnemyクラス")]
    Enemy _enemy;

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
            _animator.SetFloat("Speed", _speed);
            //ダッシュフラグをオンに
            _animator.SetBool("isRun", _isRun);
        }

        if (!_isDead)
        {
            if (_isRun)
            {
                MoveToPlayer();
            }

            StartCoroutine(StopMove());
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
            //プレイヤーの方向を向かせる
            this.transform.LookAt(_playerPosition);
            dir.y = 0;
            //移動
            _speed = _initialSpeed;
            _rb.velocity = dir.normalized * _speed;
        }

    }


    /// <summary>
    /// 動きを止めるコルーチン
    /// </summary>
    IEnumerator StopMove()
    {
        
        if (_attackDistance >= _distance)
        {           
            _isRun = false;
            Debug.Log("こうげき");
            //動きを止める
            _rb.velocity = Vector3.zero;
            _speed = 0f;

            yield return new WaitForSeconds(2f);
            AttackMove();
        }
        else
        {
            _isRun = true;
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
            
        if (_animator)
        {
            _animator.SetTrigger("Attack");
        }
        
    }


    public void Stop()
    {
        _isDead = true;
        _rb.velocity = Vector3.zero;
        _speed = 0f;
    }
}
