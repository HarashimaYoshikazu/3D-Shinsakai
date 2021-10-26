using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_playerUI;
    bool isPanel = false;

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
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isPanel)
        {
            m_playerUI.SetActive(false);
            isPanel = false;
        }
    }
}
