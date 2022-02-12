using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBase : MonoBehaviour
{
    [SerializeField,Tooltip("装備時に上がる防御力の値")] 
    int _addDefence  = 10;

    [SerializeField, Tooltip("装備の買値（正の値）")]
    int _gearPrice = 10;

    [SerializeField, Tooltip("装備のID")]
    int _gearID;
    public int GearID { get => _gearID; }


    [SerializeField,Tooltip("インベントリのパネルの名前")]
    string _inventryPanelName = "Inventory";

    [SerializeField, Tooltip("セルパネルの名前")]
    string _sellPanelName = "SellPanel";

    public void OnClick()
    {
        //インベントリのとき
        if (this.transform.parent.tag == _inventryPanelName)
        {
            Debug.Log("装備した");
            GearManager.Instance.EquipGear(this.gameObject);
            //トランスフォーム変更
            this.transform.SetParent(HomeManager.Instance.HeadPanel.transform);
        }
        else if(this.transform.parent.tag == _sellPanelName)
        {

        }
        else
        {
            Debug.Log("装備脱いだ");
            GearManager.Instance.TakeOffGear(this.gameObject);
            this.transform.SetParent(HomeManager.Instance.GearInventryPanel.transform);
        }
        
    }

   
}

