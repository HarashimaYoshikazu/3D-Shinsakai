using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    Transform _npcPos;
    GameObject _player;
    [SerializeField] MouseCamera mc;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _npcPos = this.transform.parent.transform;
    }

    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {

            Debug.Log(_npcPos);
            _player.transform.LookAt(_npcPos.transform.position) ;
        mc.enabled = false;
    }
}
