using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemorySkills : DDOLSingleton<MemorySkills>
{
    [SerializeField, Tooltip("スキルを覚えているかのフラグ")]
    public bool[] _IsSkillsLearned;
    private void Start()
    {
        if (SkillManager.Instance)
        {
            //　スキル数分の配列を確保
            _IsSkillsLearned = new bool[SkillManager.Instance.SkillParams.Length];
        }
    }
}
