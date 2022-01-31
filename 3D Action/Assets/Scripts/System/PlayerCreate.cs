using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 開始時にプレイヤーを生成するクラス
/// </summary>
public class PlayerCreate : MonoBehaviour
{
    [SerializeField, Tooltip("Playerのプレハブ")]
    GameObject _player;
    [SerializeField, Tooltip("Playerのスポーンポジション")]
    Transform _playerSpown;
    private void Awake()
    {
        //プレイヤー生成関数をイベントに登録
        //InBattleSceneManager.Instance.OnBeginBattle += InstansPlayer;
    }

    /// <summary>
    /// プレイヤーを生成する関数
    /// </summary>
    void InstansPlayer()
    {
        Debug.Log("Player生成");
        //Playerを生成
        Instantiate(_player, _playerSpown);
    }
}
