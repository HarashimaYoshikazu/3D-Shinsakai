using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPanelScript : MonoBehaviour
{
    [SerializeField] GameObject m_questionPanel;
    // Start is called before the first frame update

    public void PanelOn()
    {
        m_questionPanel.SetActive(true);
    }
    public void PanelOff()
    {
        m_questionPanel.SetActive(false);
    }
}
