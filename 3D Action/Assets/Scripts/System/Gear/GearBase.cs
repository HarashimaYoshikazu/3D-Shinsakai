using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBase : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] int _addDefence = default;
    /// <summary>カードがインベントリの何番目にあるかを表した番号</summary>
    int _gearIndex;
    [SerializeField, Tooltip("装備の買値、正の値")]
    int _gearPrice;


    [SerializeField, Tooltip("装備編成時のパネルのタグ")]
    string _gearPanelTag = "Inventory";

    [SerializeField, Tooltip("装備を売る際に表示されるインベントリパネルのタグ")]
    string _sellGearTag = "SellCardPanel";

    public int GearIndex { get => _gearIndex; set => _gearIndex = value; }
    public string Name { get => _name; set => _name = value; }


    public void OnEquipment()
    {
        PlayerPalam.Instance.Defencefluctuation(_addDefence);
    }

    public void OnTakeOff()
    {
        PlayerPalam.Instance.Defencefluctuation(-(_addDefence));
    }

    public void OnClick()
    {
        if (this.transform.parent.gameObject.CompareTag(_gearPanelTag)) //編成時
        {
            if (this is HeadGear)
            {
                this.transform.SetParent(HomeManager.Instance.HeadPanel.transform);
            }
            else if (this is BodyGear)
            {
                this.transform.SetParent( HomeManager.Instance.BodyPanel.transform);
            }
            else
            {
                this.transform.SetParent(HomeManager.Instance.LegPanel.transform);
            }
        }
        else if(this.transform.parent.gameObject.CompareTag(_sellGearTag)) //売るとき
        {

        }
        else //装備中パネル 
        {
            this.transform.SetParent(HomeManager.Instance.GearInventryPanel.transform);
        }
    }
}
