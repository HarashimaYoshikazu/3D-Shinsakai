using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    [SerializeField] int _skillCost = 1;
    int _usedCost = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ResetSkill()
    {
        MouseCamera.IsFire = false;
        PlayerStateManager.SkillPoint += _usedCost;
    }

    void FireSkill()
    {
        if (PlayerStateManager.SkillPoint>0)
        {
            PlayerStateManager.SkillPoint -= _skillCost;
            _usedCost += _skillCost;
            MouseCamera.IsFire = true;
        }
    }

}
