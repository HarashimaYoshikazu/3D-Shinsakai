using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Image _fadePanel;
    [SerializeField] Canvas _canvs;
    [SerializeField] float _fadeTime = 2f;
    public void SceneChangeSingle(string name)
    {
        if (_fadePanel)
        {
            var go =  Instantiate(_fadePanel,_canvs.transform);
            go.color = new Color(0,0,0,0);//黒

            go.DOColor(
                new Color(0, 0, 0, 1),   // 変更後の色
                _fadeTime              // 演出時間
            ).OnComplete(()=>SceneManager.LoadScene(name, LoadSceneMode.Single));
        }

        ;
    }

    public void SceneChangeAddtive(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
}
