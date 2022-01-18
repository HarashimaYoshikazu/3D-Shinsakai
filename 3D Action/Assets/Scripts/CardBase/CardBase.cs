using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardBase : MonoBehaviour
{
    /// <summary>カードの名前</summary>
    [SerializeField] string _name;

    /// <summary>カードがインベントリの何番目にあるかを表した番号</summary>
    int _cardIndex;

    public int CardIndex { get => _cardIndex; set => _cardIndex = value; }
    public string Name { get => _name; set => _name = value; }

    /// <summary>
    /// カードの効果を実行する関数
    /// </summary>
    public virtual void Execute()
    {
        Debug.Log($"{_name}が使用されています");
    }

    /// <summary>
    /// カードが押されたときにExecute関数を呼ぶ
    /// </summary>
    public void OnClick()
    {
        Execute();
    }
}
