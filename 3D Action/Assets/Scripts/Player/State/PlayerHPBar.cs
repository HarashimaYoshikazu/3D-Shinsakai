using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    static Slider _hpbar;
    public Slider Hpbar { get => _hpbar; set => _hpbar = value; }

    // Start is called before the first frame update
    void Start()
    {
        _hpbar = GameObject.Find("Slider").GetComponent<Slider>();
        _hpbar.maxValue = PlayerStateManager.Hp;
        _hpbar.value = PlayerStateManager.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void HPfluctuation(int value)
    {
        PlayerStateManager.Hp += value;
        _hpbar.value = PlayerStateManager.Hp;
    }

    public void TestHpHerasu(int dmg)
    {
        HPfluctuation(dmg);
    }
}
