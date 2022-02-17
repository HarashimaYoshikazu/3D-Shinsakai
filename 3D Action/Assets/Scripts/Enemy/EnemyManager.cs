using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 敵を生成、管理するクラス
/// </summary>
public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField,Tooltip("敵オブジェクトのプレハブ")] 
    GameObject[] _enemyPrefubs;
    [SerializeField, Tooltip("敵が生成されるTransform")]
    Transform[] _enemyGeneratePositions;

    [SerializeField, Tooltip("敵の生成時間のインターバル")]
    float _interval = 3f;
    [SerializeField, Tooltip("敵を何体まで生成させるか")]
    int _enemyLimit;

    [SerializeField, Tooltip("敵を倒した時に手に入れたものを表示するテキスト")]
    Text _getItemInfoText;

    [SerializeField, Tooltip("敵を倒した時に手に入れたものを表示するテキスト")]
    Animator _getItemInfoAnimator;

    /// <summary>生成間隔を計るためのタイマー</summary>
    float _timer = 0f;
    /// <summary>現在の敵が入っているリスト</summary>
    List<GameObject> _enemies = new List<GameObject>();

    /// <summary>敵の生成をやめるフラグ</summary>
    bool _generetorOperation = true;

    private void Start()
    {
        InBattleSceneManager.Instance.OnResult += StopGenerator;
    }

    /// <summary>
    /// 敵を生成する関数
    /// </summary>
    public void Genarate()
    {
        if (_generetorOperation)
        {
            _timer += Time.deltaTime;
            //タイムインターバルを過ぎ、敵の数が上限に達していなかったら
            if (_interval < _timer && _enemies.Count < _enemyLimit)
            {
                //敵プレハブとスポーンポジションの配列のランダムなインデックスの値を取得
                int PrefubValue = Random.Range(0, _enemyPrefubs.Length);
                int PosValue = Random.Range(0, _enemyGeneratePositions.Length);
                //タイマーをリセット
                _timer = 0f;
                Vector3 pos = new Vector3(_enemyGeneratePositions[PosValue].position.x,0f, _enemyGeneratePositions[PosValue].position.z);
                //敵をランダムな場所にインスタンスしてリストに格納
                _enemies.Add(Instantiate(_enemyPrefubs[PrefubValue], pos, Quaternion.identity));
            }
        }       
    }

    /// <summary>
    /// 敵を倒したときの処理
    /// </summary>
    /// <param name="enemy">敵</param>
    public void OnDeadEnemy(GameObject enemy)
    {
        //タイマーをリセット
        _timer = 0f;
        //該当の敵をリストから消す
        _enemies.Remove(enemy);
    }

    /// <summary>
    /// ゲーム終了時の処理
    /// </summary>
    public void StopGenerator()
    {
        //生成をやめる
        _generetorOperation = false;
        //敵を消す
        foreach (var i in _enemies)
        {
            Destroy(i);
        }
    }

    public void SetItemText(string msg)
    {
        _getItemInfoText.text = msg;
        _getItemInfoAnimator.SetTrigger("GetItem");
    }
    
}
