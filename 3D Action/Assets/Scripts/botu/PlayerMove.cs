using UnityEngine;

/// <summary>
/// 現代的なキャラクター操作スキーマを実現する。
/// 「カメラから見た方向」にキャラクター「Rigidbody.AddForce を使って」動かす。
/// 止まる時の減速具合は Rigidbody.Drag か Physics Material で調整する。
/// </summary>
public class PlayerMove : MonoBehaviour, IMatchTarget
{
    [SerializeField,Tooltip("プレイヤーが動く力の大きさ")]
    float _moveSpeed = 3;
    [SerializeField, Tooltip("プレイヤーのアニメーションのなめらかさ")] 
    float _damptime = 0.1f;

    /// <summary>プレイヤーのColiderGet</summary>
    ColiderGet _coliderGet = default;
    /// <summary>プレイヤーのRigidBody</summary>
    Rigidbody _rb = default;
    /// <summary>プレイヤーのアニメーター</summary>
    Animator _anim = default;
    /// <summary>入力された方向の XZ 平面でのベクトル</summary>
    Vector3 _dir;
    public Vector3 TargetPosition => ColiderGet.Nearbyobject.ClosestPoint(transform.position);

    void Start()
    {
        //GetCompornent
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _coliderGet = GetComponent<ColiderGet>();
        //MatchAtacckの設定
        _anim.keepAnimatorControllerStateOnDisable = true;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        // カメラのローカル座標系を基準に dir を変換する
        dir = Camera.main.transform.TransformDirection(dir);
        // カメラは斜め下に向いているので、Y 軸の値を 0 にして「XZ 平面上のベクトル」にする
        dir.y = 0;
        // 移動の入力がない時は回転させない。入力がある時はその方向にキャラクターを向ける。
        if (dir != Vector3.zero) this.transform.forward = dir;
        _rb.velocity = dir.normalized * _moveSpeed;


        if (_anim)
        {
            Vector3 walkSpeed = _rb.velocity;
            walkSpeed.y = 0;
            _anim.SetFloat("Speed", walkSpeed.magnitude);
            _anim.SetFloat("X", h, _damptime, Time.deltaTime);
            _anim.SetFloat("Y", v, _damptime, Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _coliderGet.GetEnemy();
            //攻撃のトリガー
            _anim.SetTrigger("Punching");
        }
    }
}
