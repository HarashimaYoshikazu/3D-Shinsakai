using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_playerUI;
    bool isPanel = false;
    [SerializeField] MouseCamera _mouseCamera;

    void Start()
    {

    }

    void Update()
    {
        //m_playerUI.gameObject.transform.parent.name ==
        if (Input.GetKeyDown(KeyCode.Tab) && !isPanel)
        {
            PanelOn();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isPanel)
        {
            PanelOf();
        }
    }

    public void PanelOn()
    {
        m_playerUI.SetActive(true);
        isPanel = true;
        _mouseCamera.enabled = false;
    }

    public void PanelOf()
    {
        m_playerUI.SetActive(false);
        isPanel = false;
        _mouseCamera.enabled = true;
    }
}
