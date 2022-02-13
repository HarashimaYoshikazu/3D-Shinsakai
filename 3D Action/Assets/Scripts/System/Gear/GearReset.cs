using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearReset : MonoBehaviour
{
    private void OnEnable()
    {
        GearManager.Instance.InstansGear();
    }

    private void OnDisable()
    {
        GearManager.Instance.SetFalseGear();
    }
    private void OnDestroy()
    {
        Debug.Log("しんだ");
        //InSceneGearをクリアすることで次もまたinstanceされるように
        if (GearManager.Instance)
        {
            GearManager.Instance.InSceneGears.Clear();
        }
        GearManager.Instance.isFirst = false;
    }
}
