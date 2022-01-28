using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    public void SceneChangeSingle(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void SceneChangeAddtive(string name)
    {
        SceneManager.LoadScene(name,LoadSceneMode.Additive);
    }
}
