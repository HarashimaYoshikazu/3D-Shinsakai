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
            m_playerUI.SetActive(true);
            isPanel = true;
            _mouseCamera.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isPanel)
        {
            m_playerUI.SetActive(false);
            isPanel = false;
            _mouseCamera.enabled = true;
        }
    }
}
