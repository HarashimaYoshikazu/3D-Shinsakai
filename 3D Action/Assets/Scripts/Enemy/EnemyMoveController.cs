using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField,Tooltip("このオブジェクトについているNavMeshAgentコンポーネント")] 
    NavMeshAgent _navMesh;

    /// <summary>プレイヤーとの距離を保持しておく変数</summary>
    Vector3 _playerPosition = default;

    [SerializeField,Tooltip("プレイヤーに向かって移動し始めるまでの距離")]
    float _enemyVisibleDistance;
    [SerializeField, Tooltip("攻撃が開始されるプレイヤーとの距離")]
    float _attackDistance;



    private void Start()
    {
        _playerPosition = FPSPlayerMove.Instance.transform.position;
    }
    void Update()
    {
        MoveToPlayer();
    }

    /// <summary>
    /// 距離を計りプレイヤーのpositionまで移動する関数
    /// </summary>
    void MoveToPlayer()
    {
        //このオブジェクトとプレイヤーの距離
        float distance = Vector3.Distance(this.transform.position, FPSPlayerMove.Instance.transform.position);

        //発覚範囲になったらプレイヤーに向かって動く
        if (_enemyVisibleDistance>distance)
        {
            _navMesh.SetDestination(FPSPlayerMove.Instance.transform.position);
        }

        //攻撃範囲まで近づいたら攻撃を始める
        if (_attackDistance > distance)
        {
            Debug.Log("こうげき");
            //動きを止める
            _navMesh.velocity = Vector3.zero;

            //プレイヤーにダメージを与える
            this.gameObject.GetComponent<Enemy>().Attack();
            Debug.Log($"HPは{PlayerPalam.Instance.HP}");
        }
    }
}
