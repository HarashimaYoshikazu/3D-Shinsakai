using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _navMesh;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _navMesh.SetDestination(PlayerPalam.Instance.transform.position);
    }
}
