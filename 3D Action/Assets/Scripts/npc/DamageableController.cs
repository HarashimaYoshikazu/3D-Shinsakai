using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ダメージとライフを制御するコンポーネント
/// </summary>
public class DamageableController : MonoBehaviour
{
    /// <summary>初期ライフ</summary>
    [SerializeField, Range(1, 99999)] int m_initialLife = 5000;
    /// <summary>現在のライフ</summary>
    int m_life;

    private void Start()
    {
        m_life = m_initialLife;
    }

    /// <summary>
    /// ダメージを与える
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public void Damage(int damage)
    {
        m_life -= damage;
        if (m_life < 1)
        {
            Destroy(gameObject);
        }
    }
}