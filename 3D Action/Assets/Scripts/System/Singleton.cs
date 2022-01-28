using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 継承する事でシングトン化するクラス
/// </summary>
/// <typeparam name="T">シングトン化させたいクラス</typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {            
            Instance = this as T;
            OnAwake();
            DontDestroyOnLoad(gameObject);
        }
        
    }

    /// <summary>
    /// 派生先用のAwake関数
    /// </summary>
    protected virtual void OnAwake() { }


    private void OnDestroy()
    {
        if (Instance == this)
        {
            Release();
            Instance = null;
        }
    }
    /// <summary>
    /// 派生先用のOnDestroy関数
    /// </summary>
    protected virtual void Release() { }
}
