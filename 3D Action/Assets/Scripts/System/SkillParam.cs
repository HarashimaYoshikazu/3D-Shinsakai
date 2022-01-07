using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SkillParam : MonoBehaviour
{
	[SerializeField, Tooltip("GameManagerObjectのSkillManagerComornent")] private SkillManager _skillManager;
	[SerializeField, Tooltip("スキルの種類")] private SkillType _skilltype;
	[SerializeField, Tooltip("覚えるのに必要なコスト")] private int _cost;
	[SerializeField, Tooltip("スキルの名前")] private string _skillName;
	[SerializeField, Tooltip("スキルの説明")] private string _skillInfo;
	[SerializeField, Tooltip("表示するテキスト")] private Text _text;

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
		if (_skillManager.IsSkill(_skilltype))
		{
			return;
		}
		//　スキルを覚えられるかどうかチェック
		if (_skillManager.CanLearnSkill(_skilltype, _cost))
		{
			//　スキルを覚えさせる
			_skillManager.LearnSkill(_skilltype, _cost);

			ChangeButtonColor(new Color(0f, 0f, 1f, 1f));

			_text.text = _skillName + "を覚えた";
		}
		else
		{
			_text.text = "スキルを覚えられません。";
		}
	}

	//　他のスキルを習得した後の自身のボタンの処理
	public void CheckButtonOnOff()
	{
		//　スキルを覚えられるかどうかチェック
		if (!_skillManager.CanLearnSkill(_skilltype))
		{
			ChangeButtonColor(new Color(0.8f, 0.8f, 0.8f, 0.8f));
			//　スキルをまだ覚えていない
		}
		else if (!_skillManager.IsSkill(_skilltype))
		{
			ChangeButtonColor(new Color(1f, 1f, 1f, 1f));
		}
	}
	//　スキル情報を表示
	public void SetText()
	{
		_text.text = _skillName + "：消費スキルポイント" + _cost + "\n" + _skillInfo;
	}
	//　スキル情報をリセット
	public void ResetText()
	{
		//text.text = "";
		_text.text = "スキルポイント：" + PlayerStateManagerBotu.SkillPoint;
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
		//選ばれている時の色も変えないとダメ
		cb.selectedColor = color;
		cb.highlightedColor = color;
		//　ボタンのカラー情報を設定
		button.colors = cb;
	}
}