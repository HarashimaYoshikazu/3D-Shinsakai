using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseCamera : MonoBehaviour, IMatchTarget
{
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] float _dushSpeed = 3;
    float _walkSpeed;
    [SerializeField] float _jumpSpeed = 3;
    [SerializeField] float _attackMovePower = 2f;
    [SerializeField] float _damptime = 0.1f;
    Rigidbody _rb = default;
    bool _isGrounded = true;
    bool _isMove = true;
    Animator _anim = default;

    //[SerializeField] Transform _target;
    Collider _targetCollider ;

    [SerializeField] Transform player;
    [SerializeField] Transform eye;
    //AxisState変数
    [SerializeField] AxisState vertical;
    [SerializeField] AxisState horizontal;

    [SerializeField] ColiderGet _coliderGet;

    bool isAttack = false;
    static bool isFire = false;


    public Vector3 TargetPosition => ColiderGet.Nearbyobject.ClosestPoint(transform.position);

    public static bool IsFire { get => isFire; set => isFire = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _walkSpeed = _moveSpeed;
        _anim.keepAnimatorControllerStateOnDisable = true;
        //_target.TryGetComponent(out _targetCollider);
        if (ColiderGet.Nearbyobject != null)
        {

        }

        foreach (var smb in _anim.GetBehaviours<MatchAttackSMB>())
        {
            smb.Target = this;
        }
    }

    void Update()
    {
        float h = default;
        float v = default;
        if (_isMove)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            if (_anim)
            {
                Vector3 walkSpeed = _rb.velocity;
                walkSpeed.y = 0;
                _anim.SetFloat("Speed", walkSpeed.magnitude);
            }

        }
        else if(!_isMove)
        {
            h = 0;
            v = 0;

        }
        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        // カメラのローカル座標系を基準に dir を変換する
        dir = Camera.main.transform.TransformDirection(dir);
        // カメラは斜め下に向いているので、Y 軸の値を 0 にして「XZ 平面上のベクトル」にする
        dir.y = 0;
        // 移動の入力がない時は回転させない。入力がある時はその方向にキャラクターを向ける。
        //if (dir != Vector3.zero) this.transform.forward = dir;
        // 水平方向（XZ平面上）の速度を計算する
        dir = dir.normalized * _moveSpeed;
        // 垂直方向の速度を計算する
        float y = _rb.velocity.y;
        _rb.velocity = dir * _moveSpeed + Vector3.up * y;
        _anim.SetFloat("X", h, _damptime, Time.deltaTime);
        _anim.SetFloat("Y", v, _damptime, Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed = _dushSpeed;
            _anim.SetBool("isRun", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _moveSpeed = _walkSpeed;
            _anim.SetBool("isRun", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            _coliderGet.GetEnemy();
            //攻撃のトリガー
            _anim.SetTrigger("Punching");
            isAttack = true;
        }


        //


        horizontal.Update(Time.deltaTime);
        vertical.Update(Time.deltaTime);

        var horaizontalRotation = Quaternion.AngleAxis(horizontal.Value, Vector3.up);
        var vaerticalRotation = Quaternion.AngleAxis(vertical.Value, Vector3.right);

        player.rotation = horaizontalRotation;
        eye.localRotation = vaerticalRotation;


        //if (Input.GetButtonDown("Jump") && _isGrounded)
        //{
        //    //y = _jumpSpeed;
        //}



        //damptimeを追加すると滑らかに

    }

    private void Move()
    {
        _moveSpeed = _walkSpeed;
    }
    private void Stop()
    {
        _moveSpeed = 0f;
    }
    void AttackMove()
    {
        //_rb.AddForce((this.gameObject.transform.forward - _rb.velocity) * _attackMovePower, ForceMode.Impulse);
    }
    void AttackEnd()
    {
        isAttack = false;
    }
    //stop関数を作る
    public void StopAnim()
    {
        _anim.SetBool("isMove", true);
        _isMove = false;
    }
    public void TestExit()
    {
        _anim.SetBool("isMove", false);
        _isMove = true;
    }

}
