using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ダメージとライフを制御するコンポーネント
/// </summary>
public class DamageableController : MonoBehaviour
{
    /// <summary>初期ライフ</summary>
    [SerializeField, Range(1, 99999)] int _initialLife = 5000;
    /// <summary>現在のライフ</summary>
    int _life;

    private void Start()
    {
        _life = _initialLife;
    }

    /// <summary>
    /// ダメージを与える
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public void Damage(int damage)
    {
        _life -= damage;
        if (_life < 1)
        {
            Destroy(gameObject);
        }
    }
}