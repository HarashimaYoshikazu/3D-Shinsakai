using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard2 : CardBase
{
    string ms2 = "testcard２です";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Execute()
    {
        PlayerHPBar.Instance.HPbarfluctuation(5);
    }
}
