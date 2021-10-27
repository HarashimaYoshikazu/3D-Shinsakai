using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string scenename;
    [SerializeField] GameObject panel;
    public void Change()
    {
        var fadeImage = panel.gameObject.GetComponent<Image>();
        fadeImage.enabled = true;
        var c = fadeImage.color;
        c.a = 1.0f; // 初期値
        fadeImage.color = c;

        DOTween.ToAlpha(
            () => fadeImage.color,
            color => fadeImage.color = color,
            0f, // 目標値
            1f // 所要時間
        ).OnComplete(SceneChange);
        
    }
    private void SceneChange()
    {
        SceneManager.LoadScene(scenename);
    }
}
