using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : Singleton<PlayerHPBar>
{
    Slider _hpbar;
    public Slider Hpbar { get => _hpbar; }

    void Start()
    {
        _hpbar = GameObject.Find("Slider").GetComponent<Slider>();
        Debug.Log("BAR初期化");
        _hpbar.maxValue = PlayerPalam.Instance.HP;
        _hpbar.value = PlayerPalam.Instance.HP;
    }

    /// <summary>
    /// HPが変化した際に、実際にSliderに可視表示する関数
    /// </summary>
    public void HPbarfluctuation()
    {
        if (_hpbar)
        {
            _hpbar.value = PlayerPalam.Instance.HP;
        }
        
    }

    public void TestHpHerasu(int dmg)
    {
        PlayerPalam.Instance.HPfluctuation(dmg);
    }
}
