using UnityEngine;

public class FPSShoot : Singleton<FPSShoot>
{
    [SerializeField,Tooltip("FPS のカメラ")]
    Camera _mainCamera;

    [SerializeField, Tooltip("照準となる UI オブジェクト")] 
    UnityEngine.UI.Image _crosshair;  

    [SerializeField, Tooltip("照準に敵を捕らえていない時の色")] 
    Color _noTarget = Color.white;

    [SerializeField, Tooltip("照準に敵を捕らえている時の色")] 
    Color _onTarget = Color.red;

    [SerializeField, Range(1, 200), Tooltip("射撃可能距離")]
    float _shootRange = 10f;


    [SerializeField, Tooltip("照準の Ray が当たる Layer")]
    LayerMask _shootingLayer;

    /// <summary>攻撃したらダメージを与えられる対象</summary>
    Enemy _target;

    [SerializeField, Tooltip("攻撃した時に加える力のスカラー量")] 
    float _shootPower = 50f;

    [SerializeField, Tooltip("射撃音")]
    AudioClip _shootingSfx;

    [SerializeField, Range(0f,5f), Tooltip("初期の射撃インターバル")]
    float _initialFireInterval = 0.5f;


    /// <summary>現在の射撃インターバル</summary>
    float _fireInterval ;
    public float FireInterval => _fireInterval;

   /// <summary>インターバルを計測するタイマー</summary>
    float _timer = 0;

    void Start()
    {
        _fireInterval = _initialFireInterval;
        // マウスカーソルを消す（実行中は ESC キーを押すとマウスカーソルが表示される）
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (!_mainCamera)
        {
            _mainCamera = Camera.main;
            if (!_mainCamera)
            {
                Debug.LogError("Main Camera is not found.");
            }
        }
    }

    void Update()
    {
        _timer += Time.deltaTime;
        
        Shoot();

        Aim();        
    }

    void OnDestroy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// 照準を操作する
    /// 照準にダメージを与えられる対象がいる場合に照準の色を変え、その対象を _target に保存する
    /// </summary>
    void Aim()
    {
        if (_crosshair)
        {
            Ray ray = _mainCamera.ScreenPointToRay(_crosshair.rectTransform.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _shootRange, _shootingLayer))
            {
                _target = hit.collider.GetComponent<Enemy>();

                if (_target)
                {
                    _crosshair.color = _onTarget;
                }
                else
                {
                    _crosshair.color = _noTarget;
                }
            }
            else
            {
                _target = null;
                _crosshair.color = _noTarget;
            }
        }
        
    }

    [SerializeField] bool isDebug = false;
    [SerializeField] Animator debugAnim;
    /// <summary>
    /// 敵を撃つ関数
    /// </summary>
    private void Shoot()
    {
        if (WeaponManager.Instance?.CurrentGun != WeaponManager.Instance?.GunIconPrefabs[0])
        {
            if (Input.GetButton("Fire1") && _timer >= _fireInterval)
            {
                if (isDebug)
                {
                    debugAnim.SetBool("Shoot", true);
                }
                else if (WeaponManager.Instance)
                {
                    WeaponManager.Instance.CurrentAnimator().SetBool("Shoot", true);
                }



                if (_shootingSfx)
                {
                    AudioSource.PlayClipAtPoint(_shootingSfx, this.transform.position);
                }
                if (_target)
                {
                    //ダメージを与える
                    _target.Damage(PlayerPalam.Instance.Attack);

                    Rigidbody rb = _target.GetComponent<Rigidbody>();
                    if (rb)
                    {
                        // 斜め上方向に力を加える
                        Vector3 dir = _target.transform.position - this.transform.position;
                        dir.y = 0;
                        dir = (dir.normalized + Vector3.up).normalized;
                        rb.AddForce(dir * _shootPower, ForceMode.Impulse);
                    }
                }


                _timer = 0f;
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                WeaponManager.Instance.CurrentAnimator().SetBool("Shoot", false);
                if (isDebug)
                {
                    debugAnim.SetBool("Shoot", false);
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && _timer >= _fireInterval)
            {
                if (isDebug)
                {
                    debugAnim.SetTrigger("Shoot");
                }
                else if (WeaponManager.Instance)
                {
                    WeaponManager.Instance.CurrentAnimator().SetTrigger("Shoot");
                }



                if (_shootingSfx)
                {
                    AudioSource.PlayClipAtPoint(_shootingSfx, this.transform.position);
                }
                if (_target)
                {
                    //ダメージを与える
                    _target.Damage(PlayerPalam.Instance.Attack);

                    Rigidbody rb = _target.GetComponent<Rigidbody>();
                    if (rb)
                    {
                        // 斜め上方向に力を加える
                        Vector3 dir = _target.transform.position - this.transform.position;
                        dir.y = 0;
                        dir = (dir.normalized + Vector3.up).normalized;
                        rb.AddForce(dir * _shootPower, ForceMode.Impulse);
                    }
                }


                _timer = 0f;
            }
        }

    }
    /// <summary>
    /// ファイレートを変更する関数
    /// </summary>
    /// <param name="value"></param>
    public void FireIntervalfluctuation(float value)
    {
        if(_fireInterval + value >= 0)
        {
            _fireInterval += value;
        }
        else
        {
            _fireInterval = 0.1f;
        }        
    }


    /// <summary>
    /// クロスヘアのSetActiveを変更する関数
    /// </summary>
    /// <param name="value"></param>
    public void SetCrosshair(bool value)
    {
        _crosshair.gameObject.SetActive(value);
    }

}
