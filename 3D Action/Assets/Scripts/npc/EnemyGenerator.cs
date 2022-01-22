using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField,Tooltip("敵オブジェクトのプレハブ")] 
    GameObject[] _enemyPrefubs;
    [SerializeField, Tooltip("敵が生成されるTransform")]
    Transform[] _enemyGeneratePositions;

    [SerializeField, Tooltip("敵の生成のインターバル")]
    float _interval = 3f;
    /// <summary>生成間隔を計るためのタイマー</summary>
    float _timer = 0f;

    private void Update()
    {
        Genarate();
    }
    void Genarate()
    {
        _timer += Time.deltaTime;
        if (_timer>_interval)
        {
            int PrefubValue = Random.Range(0,_enemyPrefubs.Length);
            int PosValue = Random.Range(0,_enemyGeneratePositions.Length);
            _timer = 0f;
            Instantiate(_enemyPrefubs[PrefubValue],_enemyGeneratePositions[PosValue]);
        }
    }
}
