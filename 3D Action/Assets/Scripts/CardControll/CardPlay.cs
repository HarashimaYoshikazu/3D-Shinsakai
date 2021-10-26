using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlay : MonoBehaviour
{
    GameObject m_parentPanel = null;
    IsPanelScript isPanelScript;
    private void Start()
    {
        m_parentPanel = GameObject.FindGameObjectWithTag("ParentTag");
        isPanelScript = m_parentPanel.gameObject.GetComponent<IsPanelScript>();
    }
    private void Update()
    {
        if (this.gameObject.transform.parent.name == "PlayPanel")
        {
            isPanelScript.PanelOn();
        }
    }
}
