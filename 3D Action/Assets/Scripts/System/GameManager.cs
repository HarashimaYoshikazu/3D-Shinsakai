using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("リザルトパネル関係")]
    [SerializeField, Tooltip("テキストやボタンを子オブジェクトに持つパネル")]
    GameObject _resaultPanel;
    [SerializeField, Tooltip("リザルトを出力するテキストコンポーネント")]
    Text _resultText;

    /// <summary>ダンジョン１回で手に入れたゴールド</summary>
    int _goldCount = 0;
    /// <summary>ダンジョン１回で手に入れたカード</summary>
    int _cardCount = 0;

    private void Update()
    {
        if (FPSPlayerMove.Instance.Isend)
        {
            EndStage();
        }
    }

    /// <summary>
    /// ステージをクリアしたときの処理を行う関数
    /// </summary>
    public void EndStage()
    {
        //リザルトパネルを表示
        _resaultPanel.SetActive(true);
        SetResultText();
        //ジェネレーター止める
        EnemyGenerator.Instance.StopGenerator();
    }

    /// <summary>
    /// ダンジョン内でゴールドを手に入れた時にそれをカウントしておく関数
    /// </summary>
    public void GetGoldCount(int gold)
    {
        _goldCount+= gold;
    }

    /// <summary>
    /// ダンジョン内でカードを手に入れた時にそれをカウントしておく関数
    /// </summary>
    public void GetCardCount()
    {
        _cardCount++;
    }


    /// <summary>
    /// 取得したものをリザルトテキストに出力
    /// </summary>
    void SetResultText()
    {
        if (_resultText)
        {
            if (FPSPlayerMove.Instance.Isend)
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

}
