using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField,Tooltip("カードを管理するパネル")] 
    GameObject m_playerUI;
    [SerializeField, Tooltip("スキルツリーを表示するパネル")]
    GameObject _SkillPanel;
    [SerializeField, Tooltip("プレイヤーを操作するクラス")] 
    FPSPlayerMove _playercon;
    [SerializeField, Tooltip("カード情報を表示するパネル")] 
    GameObject _cardInfo;

    /// <summary>/// パネルが表示されているかどうかのフラグ/// </summary>
    bool isPanel = false;
    bool isSkillPanel = false;
    [SerializeField] bool isHome = false;

    void Update()
    {
        if (!isHome)
        {
            InputButton();
        }
    }

    void InputButton()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isPanel)
        {
            PanelOn();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isPanel)
        {
            PanelOf();
        }
        if (Input.GetKeyDown(KeyCode.Q) && !isSkillPanel)
        {
            SkillTreeOn(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && isSkillPanel)
        {
            SkillTreeOn(false);
        }
    }

    public void PanelOn()
    {
        m_playerUI.SetActive(true);
        isPanel = true;
        if (_playercon)
        {
            _playercon.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }        

    }

    public void PanelOf()
    {
        m_playerUI.SetActive(false);
        isPanel = false;
        if (_playercon)
        {
            _playercon.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void InfoOnOf(bool isActive)
    {
        _cardInfo.SetActive(isActive);
    }
    public void SkillTreeOn(bool isactive)
    {
        _SkillPanel.SetActive(isactive);
        if (isactive)
        {
            isSkillPanel = true;
            if (_playercon)
            {
                _playercon.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            isSkillPanel = false;
            if (_playercon)
            {
                _playercon.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
