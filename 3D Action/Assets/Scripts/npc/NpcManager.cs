using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{  
    void Awake()
    {
        PlayerController.OnStartTalk += Num;
    }

    void Update()
    {
        
    }
    void Num()
    {
        Debug.Log("aa");
    }
}
