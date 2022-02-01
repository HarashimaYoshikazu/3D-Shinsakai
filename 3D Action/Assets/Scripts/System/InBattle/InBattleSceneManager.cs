using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InBattleSceneManager : Singleton<InBattleSceneManager>
{
    [Header("リザルトパネル関係")]

    [SerializeField, Tooltip("テキストやボタンを子オブジェクトに持つパネルプレハブ")]
    GameObject _resaultCanvasPrefub;

    [SerializeField, Tooltip("リザルトを出力するテキストコンポーネントプレハブ")]
    Text _resultTextPrefub;

    /// <summary>ダンジョン１回で手に入れたゴールド</summary>
    int _goldCount = 0;
    /// <summary>ダンジョン１回で手に入れたカード</summary>
    int _cardCount = 0;


    /// <summary>プレイヤーが死んでいるかのフラグ</summary>
    bool _isDead = false;

    /// <summary>プレイヤーが死ぬかクリアしているかを判定するフラグ</summary>
    bool _isEnd = false;



    /// <summary>リザルト時に呼ばれるメソッド</summary>
    public event Action OnResult;

    protected override void OnAwake()
    {        
        OnResult += SetResultText;
    }
    private void Update()
    {
        BattleUpdate();
    }

    /// <summary>
    /// BattaleScene上で実行されるUpdate
    /// </summary>
    public void BattleUpdate()
    {
        EnemyManager.Instance.Genarate();
        CheackHP();
    }

    /// <summary>
    /// ステージを脱出したときの処理を行う関数,HPが0以下になったとき、クリアコライダーに入った時のどちらかにのみ呼ばれる
    /// </summary>
    public void Result()
    {
        //エンドフラグをオンに
        _isEnd = true;
        //カーソル表示
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //リザルトイベントを呼ぶ
        OnResult();
        //ゴールドとカードのカウントをリセット
        ResetCount();

    }

    void CheackHP()
    {
        //HPが0以下になったら
        if (PlayerPalam.Instance.HP <= 0 && !_isDead)
        {
            _isDead = true;
            Result();
        }
        Debug.Log(_isDead + "HPは" + PlayerPalam.Instance.HP);
    }

    /// <summary>
    /// ダンジョン内で取得したものをリザルトテキストに出力
    /// </summary>
    void SetResultText()
    {
        
        if (_resaultCanvasPrefub && _resultTextPrefub  )
        {
            //リザルトパネル,テキストを生成
            var canvas = Instantiate(_resaultCanvasPrefub);
            Text text = Instantiate(_resultTextPrefub, canvas.transform);

            //脱出時死んでいるかでメッセージを変える
            if (!_isDead)
            {
                text.text = $"ステージクリア！今回の探索で・・・\nゴールドを{_goldCount}手に入れた！" +
                   $"\nカードを{_cardCount}枚手に入れた！";
            }
            else
            {
                text.text = $"力尽きてしまった・・・今回の探索で・・・\nゴールドを{_goldCount}手に入れた！" +
                   $"\nカードを{_cardCount}枚手に入れた！";
            }

        }
    }


    /// <summary>
    /// ダンジョン内でゴールドを手に入れた時にそれをカウントしておく関数
    /// </summary>
    public void GetGoldCount(int gold)
    {
        _goldCount += gold;
        Debug.Log(_goldCount);
    }
    /// <summary>
    /// ダンジョン内でカードを手に入れた時にそれをカウントしておく関数
    /// </summary>
    public void GetCardCount()
    {
        _cardCount++;
    }

    /// <summary>
    /// ダンジョンから抜ける際にカウントをリセットする関数
    /// </summary>
    public void ResetCount()
    {
        _goldCount = 0;
        _cardCount = 0;
    }
}
