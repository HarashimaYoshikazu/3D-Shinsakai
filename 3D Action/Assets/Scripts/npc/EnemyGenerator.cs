using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : Singleton<EnemyGenerator>
{
    [SerializeField,Tooltip("敵オブジェクトのプレハブ")] 
    GameObject[] _enemyPrefubs;
    [SerializeField, Tooltip("敵が生成されるTransform")]
    Transform[] _enemyGeneratePositions;

    [SerializeField, Tooltip("敵の生成時間のインターバル")]
    float _interval = 3f;
    [SerializeField, Tooltip("敵を何体まで生成させるか")]
    int _enemyLimit;

    /// <summary>生成間隔を計るためのタイマー</summary>
    float _timer = 0f;
    /// <summary>現在の敵の数</summary>
    int _enemyCount;

    private void Update()
    {
        Genarate();
    }

    /// <summary>
    /// 敵を生成する関数
    /// </summary>
    void Genarate()
    {
        _timer += Time.deltaTime;
        //タイムインターバルを過ぎ、敵の数が上限に達していなかったら
        if (_interval<_timer && _enemyCount<_enemyLimit)
        {
            //敵プレハブとスポーンポジションの配列のランダムなインデックスの値を取得
            int PrefubValue = Random.Range(0,_enemyPrefubs.Length);
            int PosValue = Random.Range(0,_enemyGeneratePositions.Length);
            //タイマーをリセット
            _timer = 0f;
            //敵をランダムな場所にインスタンス
            Instantiate(_enemyPrefubs[PrefubValue],_enemyGeneratePositions[PosValue]);
            //敵のカウントを増やす
            _enemyCount++;
        }
    }

    /// <summary>
    /// 敵を倒したときの処理
    /// </summary>
    public void OnDeadEnemy()
    {
        //タイマーをリセット
        _timer = 0f;
        //敵のカウントを減らす
        _enemyCount--;
    }
}
