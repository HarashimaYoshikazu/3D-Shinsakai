using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField, Tooltip("表示するテキスト")]
    Text _text;
    [SerializeField, Tooltip("売るカードを表示するPanel")]
    GameObject _sellPanel;

    private void OnEnable()
    {
        _text.text = "いらっしゃいませ！\n 所持ゴールド：" + PlayerPalam.Instance.Gold;
    }
    /// <summary>お金を減らしてインベントリにカードを追加する関数</summary>
    /// <param name="value">購入に必要なお金</param>
    public void BuyRandomCard(int value)
    {
        if (0>PlayerPalam.Instance.Gold + value)
        {
            _text.text = "ゴールドが足りません\n 所持ゴールド：" + PlayerPalam.Instance.Gold;
        }
        else
        {
            PlayerPalam.Instance.Goldfluctuation(value);
            //全てのカードからランダムなインデックスを取得
            int ran = Random.Range(0, CardManager.Instance.AllCards.Length);
            //取得したインデックスのカードを追加する
            GameObject card = CardManager.Instance.AllCards[ran];
            CardManager.Instance.AddCard(card);
            CardBase cardBase = card.GetComponent<CardBase>();
            _text.text =cardBase.Name + "を手に入れた！\n 所持ゴールド：" + PlayerPalam.Instance.Gold;
        }

    }

    public void SellCard()
    {
        _sellPanel.SetActive(true);
    }
}
