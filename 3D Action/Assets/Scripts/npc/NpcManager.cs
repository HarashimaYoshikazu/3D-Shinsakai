using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{  
    [SerializeField] GameObject _fieldPanel;
    void Awake()
    {
        EventAction.OnStartTalk += Num;
    }

    void Update()
    {
        
    }
    void Num()
    {
        Debug.Log("aa");
    }
}
