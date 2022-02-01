using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : Singleton<HomeManager>
{
    // Start is called before the first frame update
    void Start()
    {
        //テキストをデフフォルトに
        TextManager.Instance.HomeDefault();
        //HPリセット
        PlayerPalam.Instance.ResetHP();
    }

}
