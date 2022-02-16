using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEnemyController : MonoBehaviour
{
    [SerializeField] bool _death;
    float timer;
    [SerializeField] float _timeinterval = 5f;
    bool stop = false;
    [SerializeField] GameObject _touch;
    void Update()
    {
        if(!stop)
        {
            transform.Translate(0f, 0f, 0.5f * Time.deltaTime);
            timer += Time.deltaTime;
        }


        if (timer>_timeinterval && _death)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Death");
            stop = true;
            if(_touch)
            {
                _touch.SetActive(true);
            }
        }
    }
}
