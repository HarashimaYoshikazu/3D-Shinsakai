using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseSelf : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(SelfSet());
    }

    IEnumerator SelfSet()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        this.gameObject.SetActive(false);
    }
}
