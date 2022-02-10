using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearReset : MonoBehaviour
{
    bool isFirst = true;
    // Start is called before the first frame update

    private void OnEnable()
    {
        DestroyAllGear();
        GearManager.Instance.InstansGear();
    }


    void DestroyAllGear()
    {
        if (isFirst)
        {
            isFirst = false;
        }
        else
        {
            Debug.Log("けす");
            foreach (Transform child in this.transform)
            {
                Debug.Log($"{child.name}");
                //child.gameObject.SetActive(false);
                Destroy(child.gameObject);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
