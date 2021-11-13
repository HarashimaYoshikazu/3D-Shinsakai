﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UIを使っているのでこれを記入しましょう
using UnityEngine.UI;
public class QuestionUItext : MonoBehaviour
{
    // nameText:喋っている人の名前
    // talkText:喋っている内容やナレーション
    Text _nameText = default;
    Text _talkText = default;

    public bool _playing = false;
    public float _textSpeed = 0.1f;
    AudioSource _audioSource = default;
    GameObject _child;
    [SerializeField]GameObject _yesbutton;
    [SerializeField]GameObject _nobutton;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _child = GameObject.Find("Text");
        _talkText = _child.GetComponent<Text>();
        Debug.Log("panelOpen");
        DrawText( "このカードを使用しますか？");
    }


    // クリックで次のページを表示させるための関数
    public bool Q_IsSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;

        }
        return false;
    }

    // ナレーション用のテキストを生成する関数
    public void DrawText(string text)
    {
        StartCoroutine("CoDrawText", text);
    }
    // 通常会話用のテキストを生成する関数
    public void DrawText(string name, string text)
    {
        _nameText.text = name + "\n「";
        StartCoroutine("CoDrawText", text + "」");
    }

    // テキストがヌルヌル出てくるためのコルーチン
    IEnumerator CoDrawText(string text)
    {
        _playing = true;
        float time = 0;
        while (true)
        {
            yield return 0;
            time += Time.deltaTime;

            // クリックされると一気に表示
            if (Q_IsSpace()) break;
 
            int len = Mathf.FloorToInt(time / _textSpeed);
            if (len > text.Length) break;
            _talkText.text = text.Substring(0, len);
        }
        _yesbutton.SetActive(true);
        _nobutton.SetActive(true);

        _talkText.text = text;
        yield return 0;
        _playing = false;
    }
}