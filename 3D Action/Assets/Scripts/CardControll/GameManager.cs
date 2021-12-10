using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_playerUI;
    bool isPanel = false;
    [SerializeField] PlayerController _playercon;
    [SerializeField] GameObject _cardInfo;
    [SerializeField] GameObject _SkillPanel;

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
        _playercon.enabled = false;
    }

    public void PanelOf()
    {
        m_playerUI.SetActive(false);
        isPanel = false;
        _playercon.enabled = true;
    }

    public void InfoOnOf(bool isActive)
    {
        _cardInfo.SetActive(isActive);
    }
    public void SkillTreeOn(bool isactive)
    {
        _SkillPanel.SetActive(isactive);
    }
}
