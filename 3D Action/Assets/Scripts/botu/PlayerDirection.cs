using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    Transform _npcPos;
    GameObject _player;
    [SerializeField] PlayerController mc;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _npcPos = this.transform.parent.transform;
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        _player.transform.LookAt(_npcPos.transform.position);
        //
        mc.enabled = false;
        mc.StopAnim();
        //
        mc.MoveSpeed = 0;
    }
}
