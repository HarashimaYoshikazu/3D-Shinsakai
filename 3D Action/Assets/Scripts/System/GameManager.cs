using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 現在の状態遷移をシーンをまたいで管理するクラス
/// </summary>
public class GameManager : DDOLSingleton<GameManager>
{
    /// <summary>現在のState</summary>
    State _currentState;
    public State CurrentState => _currentState;

    private void Start()
    {
        _currentState = State.Start;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case State.Start:
                break;
            case State.Home:
                break;
            case State.Battle:
                break;
            case State.Result:
                break;
        }
    }

    /// <summary>
    /// 現在のStateを変更する関数
    /// </summary>
    /// <param name="updateState">変更後のStete</param>
    public void StateChange(State updateState)
    {
        StateBegin();
        _currentState = updateState;
    }

    void StateBegin()
    {

        switch (_currentState)
        {
            case State.Start:
                break;
            case State.Home:
                break;
            case State.Battle:
                break;
            case State.Result:
                break;
        }

    }

}

/// <summary>
/// 現在のStateが宣言されたenum
/// </summary>
public enum State
{
    Start,
    Home,
    Battle,
    Result
}

