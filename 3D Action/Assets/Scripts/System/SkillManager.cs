using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// スキルの種類
/// </summary>
public enum SkillType
{
	Attack1,
	Defense1,
	Attack2,
	Defense2,
	Speed1,
	Speed2,
	//Combo,
	//Master
};

public class SkillManager : Singleton<SkillManager>
{
	//[SerializeField,Tooltip("スキルポイントの初期化値")] private int _skillPoint = 5;
	//　スキルを覚えているかどうかのフラグ
	[SerializeField,Tooltip("スキルを覚えているかの試験用フラグ")] private bool[] _IsSkillsLearned;
	//　スキル毎のパラメータ
	[SerializeField,Tooltip("スキル")] private SkillParam[] _skillParams;
	//　スキルポイントを表示するテキストUI(要変更)
	[SerializeField, Tooltip("スキルポイントを表示するテキストUI")] Text skillText;

	[SerializeField,Header("スキル取得"), Tooltip("攻撃力")] int[] _addAttack = new int[2];
	[SerializeField, Tooltip("防御力")] int[] _addDefence = new int[2];

	void Start()
	{
		//　スキル数分の配列を確保
		_IsSkillsLearned = new bool[_skillParams.Length];
		SetText();
		//PlayerStateManagerBotu.SkillPoint = _skillPoint;
	}

	//　スキルを覚える
	public void LearnSkill(SkillType type, int point)
	{
		_IsSkillsLearned[(int)type] = true;
        switch(type)
		{
			case SkillType.Attack1:
				PlayerPalam.Instance.Attackfluctuation(_addAttack[0]); 
				Debug.Log("攻撃力は"+ PlayerPalam.Instance.Attack);
				break;
			case SkillType.Defense1:
				PlayerPalam.Instance.Defencefluctuation(_addDefence[0]);
				Debug.Log("攻撃力は" + PlayerPalam.Instance.Defence);
				break;
			case SkillType.Attack2:
				PlayerPalam.Instance.Attackfluctuation(_addAttack[1]);
				Debug.Log("攻撃力は" + PlayerPalam.Instance.Attack);
				break;
			case SkillType.Defense2:
				PlayerPalam.Instance.Defencefluctuation(_addDefence[1]);
				Debug.Log("攻撃力は" + PlayerPalam.Instance.Defence);
				break;
			case SkillType.Speed1:
				//PlayerPalam.Instance.Defencefluctuation(_addDefence[0]);
				Debug.Log("スピードUP1");
				break;
			case SkillType.Speed2:
				//PlayerPalam.Instance.Attackfluctuation(_addAttack[1]);
				Debug.Log("スピードUP２");
				break;
		}
		SetSkillPoint(point);
		SetText();
		CheckOnOff();
	}
	//　スキルを覚えているかどうかのチェック
	public bool IsSkill(SkillType type)
	{
		return _IsSkillsLearned[(int)type];
	}
	//ここらへんPlayerParamと比較していらないとこ削る
	//　スキルポイントを減らす
	public void SetSkillPoint(int point)
	{
		PlayerPalam.Instance.SkillPointfluctuation(-(point));
	}
	//　スキルポイントを取得
	public int GetSkillPoint()
	{
		return PlayerPalam.Instance.SkillPoint;
	}
	//　スキルを覚えられるかチェック
	public bool CanLearnSkill(SkillType type, int spendPoint = 0)
	{
		//　持っているスキルポイントが足りない
		if (PlayerPalam.Instance.SkillPoint < spendPoint)
		{
			return false;
		}
        //　攻撃UP2は攻撃UP1を覚えていなければダメ
        if (type == SkillType.Attack2)
        {
            return _IsSkillsLearned[(int)SkillType.Attack1];
            //　防御UP2は防御UP1を覚えていなければダメ
        }
        else if (type == SkillType.Defense2)
        {
            return _IsSkillsLearned[(int)SkillType.Defense1];
            //　速さUP2は速さUP1を覚えていなければダメ
        }
        else if (type == SkillType.Speed2)
        {
            return _IsSkillsLearned[(int)SkillType.Speed1];
            //　コンボは攻撃UP2と防御２を覚えていなければダメ
        }
        //else if (type == SkillType.Combo)
        //{
        //	return skills[(int)SkillType.Attack2] && skills[(int)SkillType.Defense2];
        //	//　マスタースキルは全てのスキルを覚えていなければダメ
        //}
        //else if (type == SkillType.Master)
        //{
        //	return skills[(int)SkillType.Attack2] && skills[(int)SkillType.Defense2] && skills[(int)SkillType.Speed2] && skills[(int)SkillType.Combo];
        //}
        return true;
	}
	//　スキル毎にボタンのオン・オフをする処理を実行させる
	void CheckOnOff()
	{
		foreach (var skillParam in _skillParams)
		{
			skillParam.CheckButtonOnOff();
		}
	}

	void SetText()
	{
		skillText.text = "スキルポイント：" + PlayerPalam.Instance.SkillPoint;
	}
}