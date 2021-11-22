using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager 
{
    static int hp;
    static int attack = 5;
    static int gold = 0;
    public static int Hp { get => hp; set => hp = value; }
    public static int Attack { get => attack; set => attack = value; }
    public static int Gold { get => gold; set => gold = value; }

}
