using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestCard : CardBase
{
    string ms = "testcard１です";
    FieldPanelScript _fp;

    // Start is called before the first frame update
    void Start()
    {
        _fp = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FieldPanelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Execute()
    {
        ColiderGet colget = GameObject.FindGameObjectWithTag("Player").GetComponent<ColiderGet>();
        if (ColiderGet.Nearbyobject.gameObject.tag =="enemy")
        {
            colget.GetEnemy();
            GameObject drop = ColiderGet.Nearbyobject.gameObject.GetComponent<Unit>().DropCard;
            FieldPanelScript fieldpanel = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FieldPanelScript>();
            fieldpanel.FieldPanelOn();
            fieldpanel.FieldText($"敵は{name}を持っている！");
        }
        else
        {
            FieldPanelScript fieldpanel = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FieldPanelScript>();
            fieldpanel.FieldPanelOn();
            fieldpanel.FieldText($"敵がちかくにいない・・・");
            StartCoroutine(SelfSet());
        }

    }
    IEnumerator SelfSet()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        _fp.FieldPanelOff();
    }
}
