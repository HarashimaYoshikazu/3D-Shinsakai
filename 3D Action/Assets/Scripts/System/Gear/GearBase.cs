using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GearBase : MonoBehaviour
{
    [SerializeField,Tooltip("装備時に上がる防御力の値")] 
    protected int _addDefence  = 10;

    [SerializeField, Tooltip("装備の買値（正の値）")]
    protected int _gearPrice = 10;

    [SerializeField, Tooltip("装備のID")]
    protected int _gearID;
    public int GearID { get => _gearID; }

    [SerializeField, Tooltip("装備の名前")]
    string _gearName;
    public string GearName => _gearName;

    [SerializeField,Tooltip("インベントリのパネルの名前")]
    string _inventryPanelName = "Inventory";

    [SerializeField, Tooltip("セルパネルの名前")]
    string _sellPanelName = "SellPanel";

    protected abstract void OnEquip();

    protected abstract void OnTakeOff();

    public void OnClick()
    {
        if (this.transform.parent.tag ==_inventryPanelName)
        {

                OnEquip();

        }
        else if (this.transform.parent.tag == _sellPanelName)
        {

        }
        else
        {
                OnTakeOff();           
        }
        
    }

   
}

