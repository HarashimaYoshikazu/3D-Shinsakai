using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour
{
    [SerializeField, Tooltip("Playerのプレハブ")]
    GameObject _player;
    [SerializeField, Tooltip("Playerのスポーンポジション")]
    Transform _playerSpown;
    private void Start()
    {
        Debug.Log("Player生成");
        //Playerを生成
        Instantiate(_player, _playerSpown);
    }
}
