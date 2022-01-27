using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerMove : Singleton<FPSPlayerMove>
{
    [SerializeField, Tooltip("動く速さ")]
    float _movingSpeed = 5f;

    [SerializeField, Tooltip("キャラクターの Rigidbody")]
    Rigidbody _rb;

    [SerializeField,Tooltip("キャラクターの Animator")] 
    Animator _anim;

    [SerializeField,Tooltip("ゲームクリア判定を行うためのタグ")]
    string _tag = "End";

    /// <summary>終了したかを判定するフラグ</summary>
    bool isEnd = false;
    public bool Isend => isEnd;

    void Update()
    {
        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        // 入力方向のベクトルを組み立てる
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする
            this.transform.forward = dir;   // そのベクトルの方向にオブジェクトを向ける

            // 前方に移動する。ジャンプした時の y 軸方向の速度は保持する。
            Vector3 velo = this.transform.forward * _movingSpeed;
            velo.y = _rb.velocity.y;
            _rb.velocity = velo;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //出口のオブジェクトに入ったら
        if (other.tag ==_tag)
        {
            isEnd = true; //flagをTrueに
            //カーソル表示
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
