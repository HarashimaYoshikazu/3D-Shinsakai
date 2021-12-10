using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPanelScript : MonoBehaviour
{
    [SerializeField] GameObject _fieldPanel;
    [SerializeField] Text _fieldtext;
    [SerializeField] UItext _uItext;
    void Start()
    {
        EventAction.OnStartTalk += FieldPanelOn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FieldPanelOn()
    {
        _fieldPanel.SetActive(true);
    }
    public void FieldPanelOff()
    {
        _fieldPanel.SetActive(false);
    }
    public void FieldText(string message)
    {
        _uItext.DrawText(message,_fieldtext);
        //_text.text = fieldtext;
    }
    public IEnumerator SelfSet()
    {        
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        FieldPanelOff();
    }
}
