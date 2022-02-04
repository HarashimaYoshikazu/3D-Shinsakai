using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{
    //[SerializeField,Tooltip("このオブジェクトについているNavMeshAgentコンポーネント")] 
    //NavMeshAgent _navMesh;

    [SerializeField] Rigidbody _rb;
    /// <summary>プレイヤーとの距離を保持しておく変数</summary>
    Vector3 _playerPosition = default;

    [SerializeField] float _speed = 10f;

    [SerializeField,Tooltip("プレイヤーに向かって移動し始めるまでの距離")]
    float _enemyVisibleDistance;
    [SerializeField, Tooltip("攻撃が開始されるプレイヤーとの距離")]
    float _attackDistance;
    bool isStop = false;


    private void Start()
    {
            
        
        
    }
    private void FixedUpdate()
    {
        _playerPosition = FPSPlayerMove.Instance.transform.position;
        //y軸を初期化
        _playerPosition.y = this.transform.position.y;
        if (!isStop)
        {
            MoveToPlayer();
        }

        Stop();
    }

    /// <summary>
    /// 距離を計りプレイヤーのpositionまで移動する関数
    /// </summary>
    void MoveToPlayer()
    {
        //このオブジェクトとプレイヤーの距離
        float distance = Vector3.Distance(this.transform.position, FPSPlayerMove.Instance.transform.position);
        Vector3 move = FPSPlayerMove.Instance.transform.position - this.transform.position;

        //発覚範囲になったらプレイヤーに向かって動く
        if (_enemyVisibleDistance>distance)
        {
            this.transform.LookAt(_playerPosition);
            //_navMesh.SetDestination(FPSPlayerMove.Instance.transform.position);
            move.y = 0;
            _rb.velocity = move.normalized * _speed;
        }


    }

    private void Stop()
    {
        float distance = Vector3.Distance(this.transform.position, FPSPlayerMove.Instance.transform.position);
        //攻撃範囲まで近づいたら攻撃を始める
        if (_attackDistance > distance)
        {
            isStop = true;
            Debug.Log("こうげき");
            //動きを止める
            //_navMesh.velocity = Vector3.zero;
            _rb.velocity = Vector3.zero;

            //プレイヤーにダメージを与える
            this.gameObject.GetComponent<Enemy>().Attack();
            Debug.Log($"HPは{PlayerPalam.Instance.HP}");
        }
        else
        {
            isStop = false;
        }
    }
}
