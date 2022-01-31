using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : Singleton<PlayerCreate>
{
    [SerializeField, Tooltip("Playerのプレハブ")]
    GameObject _player;
    [SerializeField, Tooltip("Playerのスポーンポジション")]
    Transform _playerSpown;
    
    /// <summary>
    /// プレイヤーを生成する関数
    /// </summary>
    public void InstansPlayer()
    {
        Debug.Log("Player生成");
        //Playerを生成
        Instantiate(_player, _playerSpown);
    }
}
