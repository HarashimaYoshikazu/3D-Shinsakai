using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardBase : MonoBehaviour
{
    /// <summary>カードの名前</summary>
    [SerializeField] string _name;

    /// <summary>カードがインベントリの何番目にあるかを表した番号</summary>
    int _cardIndex;

    [SerializeField,Tooltip("カードの買値、正の値")]
    int _cardPrice;

    [SerializeField,Tooltip("出撃時のインベントリパネルのタグ")] 
    string _inventoryPanelTag = "Inventory";
    [SerializeField,Tooltip("カードを売る際に表示されるインベントリパネルのタグ")]
    string _sellCardTag = "SellCardPanel";

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
        //親オブジェクトのタグがインベントリパネルだったら
        if (this.transform.parent.gameObject.tag ==_inventoryPanelTag)
        {
            Execute();
            Destroy(this.gameObject);
        }
        //セルカードタグだったら
        else if (this.transform.parent.gameObject.tag == _sellCardTag)
        {
            ShopManager.Instance.SellCard(_cardIndex,_cardPrice/2,this.gameObject);
        }
        
    }
}
