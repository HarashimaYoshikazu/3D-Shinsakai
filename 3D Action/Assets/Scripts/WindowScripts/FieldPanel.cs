using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPanel : MonoBehaviour
{
    [SerializeField] GameObject _fieldPanel;
    [SerializeField] Text _text;
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
    public void FieldText(string fieldtext)
    {
        _text.text = fieldtext;
    }
}
