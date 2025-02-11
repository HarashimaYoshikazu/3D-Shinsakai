﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UIを使っているのでこれを記入しましょう
using UnityEngine.UI;
public class UItext : MonoBehaviour
{
    // nameText:喋っている人の名前
    // talkText:喋っている内容やナレーション
    public Text nameText;
    public Text talkText;

    public bool playing = false;
    public float textSpeed = 0.1f;
    AudioSource audioSource = default;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // クリックで次のページを表示させるための関数
    public bool IsSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;

        }
        return false;
    }

    // ナレーション用のテキストを生成する関数
    public void DrawText(string text, Text talk)
    {
        StartCoroutine(CoDrawText(text, talk));
    }
    // 通常会話用のテキストを生成する関数
    public void DrawText(string name, string text,Text talk)
    {
        nameText.text = name + "\n「";
        StartCoroutine(CoDrawText(text,talk));
    }

    // テキストがヌルヌル出てくるためのコルーチン
    IEnumerator CoDrawText(string text,Text talk)
    {
        playing = true;
        float time = 0;
        while (true)
        {
            yield return 0;
            time += Time.deltaTime;

            // クリックされると一気に表示
            if (IsSpace()) break;

            int len = Mathf.FloorToInt(time / textSpeed);
            if (len > text.Length) break;
            talk.text = text.Substring(0, len);
        }
        talk.text = text;
        yield return 0;
        playing = false;
    }
}