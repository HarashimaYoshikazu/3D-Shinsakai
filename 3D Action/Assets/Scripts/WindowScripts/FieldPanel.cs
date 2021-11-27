using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPanel : MonoBehaviour
{
    [SerializeField] GameObject _fieldPanel;
    [SerializeField] Text _fieldtext;
    [SerializeField] UItext _uItext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FieldPanelSetActive(bool isActive)
    {
        _fieldPanel.SetActive(isActive);
    } 
    public void FieldText(string message)
    {
        _uItext.DrawText(message,_fieldtext);
        //_text.text = fieldtext;
    }
}
