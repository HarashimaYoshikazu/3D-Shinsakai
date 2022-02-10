using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GearBase : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] int _addDefence = default;

    [SerializeField,Tooltip("カードのID")]
    int _gearID;
    public int GeatID => _gearID;

    [SerializeField, Tooltip("装備の買値、正の値")]
    int _gearPrice;


    [SerializeField, Tooltip("装備編成時のパネルのタグ")]
    string _gearPanelTag = "Inventory";

    [SerializeField, Tooltip("装備を売る際に表示されるインベントリパネルのタグ")]
    string _sellGearTag = "SellCardPanel";

    public int GearIndex { get => _gearID; set => _gearID = value; }
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
            SetTransformGear();
            GearManager.Instance.EquipGear(this);
        }
        else if(this.transform.parent.gameObject.CompareTag(_sellGearTag)) //売るとき
        {

        }
        else //装備中パネル 
        {
            this.transform.SetParent(HomeManager.Instance.GearInventryPanel.transform);
        }
    }
    /// <summary>
    /// ボタンが押された際にトランスフォームを変更する関数
    /// </summary>
    protected abstract void SetTransformGear();
}
