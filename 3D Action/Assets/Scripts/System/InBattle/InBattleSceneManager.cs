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

    [SerializeField, Tooltip("敵を倒した時に手に入れたものを表示するテキスト")]
    Text _getItemInfoText;

    [SerializeField, Tooltip("敵を倒した時に手に入れたものを表示するテキスト")]
    Animator _getItemInfoAnimator;


    [SerializeField, Tooltip("銃のカメラオブジェクト")]
    GameObject _gunCamera;
    public GameObject GunCamera => _gunCamera;
    

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
        //gearManagerで保存した番号の武器をinstance
        if (WeaponManager.Instance)
        {
            WeaponManager.Instance.InstanceWeaponObject();
        }               
    }

    bool isStart = false;
    public void StartTrue() { isStart = true; }

    private void Update()
    {
        if(isStart)
        {
            BattleUpdate();
        }       
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
                   $"\nカードを{_cardCount}枚手に入れた！\n武器を手に入れた！";

                int n = UnityEngine.Random.Range(0, WeaponManager.Instance.GunIconPrefabs.Length);
                //アイコンオブジェクトを追加
                WeaponManager.Instance.WeaponIconInventry.Add(WeaponManager.Instance.GunIconPrefabs[n]);
                
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

    public void SetItemText(string msgtext)
    {
        _getItemInfoText.text = msgtext;
        _getItemInfoAnimator.SetTrigger("GetItem");
    }
}
