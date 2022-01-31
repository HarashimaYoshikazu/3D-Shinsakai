using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : DDOLSingleton<GameManager>
{

    [Header("リザルトパネル関係")]
    [SerializeField, Tooltip("テキストやボタンを子オブジェクトに持つパネルプレハブ")]
    GameObject _resaultPanel;
    [SerializeField, Tooltip("リザルトを出力するテキストコンポーネントプレハブ")]
    Text _resultTextPrefub;
    /// <summary>生成した後のテキスト</summary>
    Text _resultText;

    /// <summary>ダンジョン１回で手に入れたゴールド</summary>
    int _goldCount = 0;
    /// <summary>ダンジョン１回で手に入れたカード</summary>
    int _cardCount = 0;

    /// <summary>現在のState</summary>
    State _currentState;

    private void Start()
    {
        _currentState = State.Start;
    }
    private void Update()
    {
        switch (_currentState)
        {
            case State.Start:
                break;
            case State.Home:
                break;
            case State.Battle:
                ResetCount();
                PlayerCreate.Instance.InstansPlayer();
                EnemyManager.Instance.Genarate();
                break;
            case State.Result:
                Result();
                break;
        }
    }

    public void Home()
    {

    }

    /// <summary>
    /// ステージをクリアしたときの処理を行う関数
    /// </summary>
    public void Result()
    {
        //カーソル表示
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //リザルトパネルを生成
        if (_resaultPanel)
        {
            var panel = Instantiate(_resaultPanel);
            _resultText =　Instantiate(_resultTextPrefub,panel.transform);
            SetResultText();
        }       
        
        //ジェネレーター止める
        EnemyManager.Instance.StopGenerator();

        //HPリセット
        PlayerPalam.Instance.ResetHP();
        FPSPlayerMove.Instance.ResetEnd();
    }

    /// <summary>
    /// ダンジョン内でゴールドを手に入れた時にそれをカウントしておく関数
    /// </summary>
    public void GetGoldCount(int gold)
    {
        _goldCount+= gold;
    }

    public void ResetCount()
    {
        _goldCount = 0;
        _cardCount = 0;
    }

    /// <summary>
    /// ダンジョン内でカードを手に入れた時にそれをカウントしておく関数
    /// </summary>
    public void GetCardCount()
    {
        _cardCount++;
    }

    /// <summary>
    /// ダンジョン内で取得したものをリザルトテキストに出力
    /// </summary>
    void SetResultText()
    {
        if (_resultTextPrefub)
        {
            if (FPSPlayerMove.Instance.IsAllive)
            {
                _resultText.text = $"ステージクリア！今回の探索で・・・\nゴールドを{_goldCount}手に入れた！" +
                   $"\nカードを{_cardCount}枚手に入れた！";
            }
            else
            {
                _resultText.text = $"力尽きてしまった・・・今回の探索で・・・\nゴールドを{_goldCount}手に入れた！" +
                   $"\nカードを{_cardCount}枚手に入れた！";
            }

        }
    }

    /// <summary>
    /// 現在のStateを変更する関数
    /// </summary>
    /// <param name="updateState">変更後のStete</param>
    void StateChange(State updateState)
    {
        _currentState = updateState;
    }

}

public enum State
{
    Start,
    Home,
    Battle,
    Result
}

