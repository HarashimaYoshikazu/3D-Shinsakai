using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard : CardBase
{
    string ms = "testcard１です";

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
        ColiderGet colget = GameObject.FindGameObjectWithTag("Player").GetComponent<ColiderGet>();
        colget.GetEnemy();
        GameObject drop = ColiderGet.Nearbyobject.gameObject.GetComponent<Unit>().DropCard;
        FieldPanel fieldpanel = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FieldPanel>();
        fieldpanel.FieldPanelSetActive(true);
        fieldpanel.FieldText($"敵は{name}を持っている！");
    }
}
