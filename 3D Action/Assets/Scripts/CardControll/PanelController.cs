using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField,Tooltip("カードを管理するパネル")] 
    GameObject _cardPanel;
    [SerializeField, Tooltip("スキルツリーを表示するパネル")]
    GameObject _SkillPanel;
    [SerializeField, Tooltip("プレイヤーを操作するクラス")] 
    FPSPlayerMove _playercon;
    [SerializeField, Tooltip("カード情報を表示するパネル")] 
    GameObject _cardInfo;

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
        if (Input.GetKeyDown(KeyCode.Tab) && !_cardPanel.gameObject.activeSelf)
        {
            CardPanelOn();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && _cardPanel.gameObject.activeSelf)
        {
            CardPanelOf();
        }
        if (Input.GetKeyDown(KeyCode.Q) && !_SkillPanel)
        {
            SkillTreeOn(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && _SkillPanel)
        {
            SkillTreeOn(false);
        }
    }

    /// <summary>
    /// インベントリパネルを表示させる関数
    /// </summary>
    public void CardPanelOn()
    {
        //カードのSetActiveをtrueにする
        _cardPanel.SetActive(true);

        _playercon.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;        

    }

    /// <summary>
    /// インベントリパネルを非表示にする関数
    /// </summary>
    public void CardPanelOf()
    {
        //カードのパネルを表示
        _cardPanel.SetActive(false);

        //操作を受け付けるように
        _playercon.enabled = true;

        //カーソルを表示しないように
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
            if (_playercon)
            {
                _playercon.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            if (_playercon)
            {
                _playercon.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
