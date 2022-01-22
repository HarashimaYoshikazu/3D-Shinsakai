using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField,Tooltip("このオブジェクトについているNavMeshAgentコンポーネント")] 
    NavMeshAgent _navMesh;

    /// <summary>プレイヤーとの距離を保持しておく変数</summary>
    Vector3 _playerPosition;

    [SerializeField,Tooltip("プレイヤーに向かって移動し始めるまでの距離")]
    float _enemyVisibleDistance;
    [SerializeField, Tooltip("攻撃が開始されるプレイヤーとの距離")]
    float _attackDistance;

    private void Start()
    {
        _playerPosition = PlayerPalam.Instance.transform.position;
    }
    void Update()
    {
        MoveToPlayer();
        Attack();
    }

    /// <summary>
    /// プレイヤーのpositionまで移動する関数
    /// </summary>
    void MoveToPlayer()
    {
        float distance = Vector3.Distance(this.transform.position, PlayerPalam.Instance.transform.position);
        if (_enemyVisibleDistance>distance)
        {

        }
        _navMesh.SetDestination(PlayerPalam.Instance.transform.position);
    }

    void Attack()
    {
        float distance = Vector3.Distance(this.transform.position, PlayerPalam.Instance.transform.position); 
        if (_attackDistance > distance)
        {
            Debug.Log("こうげき");
        }
    }
}
