using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SkillParam : MonoBehaviour
{
	[SerializeField, Tooltip("スキルの種類")] 
	SkillType _skilltype;
	[SerializeField, Tooltip("覚えるのに必要なコスト")]
	int _cost;
	[SerializeField, Tooltip("スキルの名前")] 
	string _skillName;
	[SerializeField, Tooltip("スキルの説明")] 
	string _skillInfo;

	// Use this for initialization
	void Start()
	{
		//　スキルを覚えられる状態でなければボタンを無効化
		CheckButtonOnOff();
	}

	//　スキルボタンを押した時に実行するメソッド
	public void OnClick()
	{
		//　スキルを覚えていたら何もせずreturn
		if (SkillManager.Instance.IsSkill(_skilltype))
		{
			return;
		}
		//　スキルを覚えられるかどうかチェック
		if (SkillManager.Instance.CanLearnSkill(_skilltype, _cost))
		{
			//　スキルを覚えさせる
			SkillManager.Instance.LearnSkill(_skilltype, _cost);

			//ボタンの色変える
			ChangeButtonColor(Color.blue);

			TextManager.Instance.SetMessage(_skillName + "を覚えた");
		}
		else
		{
			TextManager.Instance.SetMessage("スキルを覚えられません。");
		}
	}

	//　他のスキルを習得した後の自身のボタンの処理
	public void CheckButtonOnOff()
	{
		//すでに覚えていたら青く（覚えたときと同じ色）
		if (SkillManager.Instance.IsSkill(_skilltype))
		{
			ChangeButtonColor(Color.blue);
		}
		//　スキルを覚えられたら白く
		else if (SkillManager.Instance.CanLearnSkill(_skilltype))
		{
			ChangeButtonColor(Color.white);
			
		}
		//　スキルをまだ覚えていないなら灰色
		else if (!SkillManager.Instance.IsSkill(_skilltype))
		{
			ChangeButtonColor(Color.grey);
		}
	}
	//　スキル情報を表示
	public void SetText()
	{
		TextManager.Instance.SetMessage(_skillName + "：消費スキルポイント" + _cost + "\n" + _skillInfo);
	}
	//　スキル情報をリセット
	public void ResetText()
	{
		//text.text = "";
		TextManager.Instance.SetMessage("スキルポイント：" + PlayerPalam.Instance.SkillPoint);
	}
	//　ボタンの色を変更する
	public void ChangeButtonColor(Color color)
	{
		//　ボタンコンポーネントを取得
		Button button = gameObject.GetComponent<Button>();
		//　ボタンのカラー情報を取得（一時変数を作成し、色情報を変えてからそれをbutton.colorsに設定しないとエラーになる）
		ColorBlock cb = button.colors;
		//　取得済みのスキルボタンの色を変える
		cb.normalColor = color;
		cb.pressedColor = color;
		////選ばれている時の色も変えないとダメ
		cb.selectedColor = color;
		cb.highlightedColor = color;
		//　ボタンのカラー情報を設定
		button.colors = cb;
	}
}