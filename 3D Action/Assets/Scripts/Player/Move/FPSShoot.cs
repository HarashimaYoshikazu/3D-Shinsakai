using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FPSShoot : Singleton<FPSShoot>
{
    [SerializeField,Tooltip("FPS のカメラ")]
    Camera _mainCamera;

    [SerializeField, Tooltip("照準となる UI オブジェクト")] 
    Image _crosshair;

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

    /// <summary>攻撃したらダメージを与えられる対象</summary>
    Chest _chest;

    [SerializeField, Tooltip("攻撃した時に加える力のスカラー量")] 
    float _shootPower = 50f;

    [SerializeField, Tooltip("射撃音")]
    AudioClip _shootingSfx;


    [SerializeField, Tooltip("ガイドを表示するテキスト")]
    Text _displayText;



   /// <summary>インターバルを計測するタイマー</summary>
    float _timer = 0;

    void Start()
    {
        
        // マウスカーソルを消す
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
        OpenChest();
    }

    void OnDestroy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>レイ</summary>
    RaycastHit _hit;

    [SerializeField,Tooltip("血のエフェクト")] 
    GameObject _efectprefab;

    /// <summary>
    /// 照準を操作する
    /// 照準にダメージを与えられる対象がいる場合に照準の色を変え、その対象を _target に保存する
    /// </summary>
    void Aim()
    {
        if (_crosshair)
        {
            Ray ray = _mainCamera.ScreenPointToRay(_crosshair.rectTransform.position);
            

            if (Physics.Raycast(ray, out _hit, _shootRange, _shootingLayer))
            {
                _target = _hit.collider.GetComponent<Enemy>();
                _chest = _hit.collider.GetComponent<Chest>();

                if (_target || _chest)
                {
                    _crosshair.color = _onTarget;
                }
                else
                {
                    _crosshair.color = _noTarget;
                }

                if (_chest)
                {
                    _displayText.text = $"[E]ボタンで開けられるよ！";
                }
            }
            else
            {
                _displayText.text = "";
                _target = null;
                _chest = null;
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
        //ピストルの時は単発に
        if (WeaponManager.Instance?.CurrentGun != WeaponManager.Instance?.GunIconPrefabs[0] || isDebug)
        {
            if (Input.GetButton("Fire1") && _timer >= PlayerPalam.Instance.FireInterval)
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
                    var ef =  Instantiate(_efectprefab,_hit.point,Quaternion.identity);
                    Destroy(ef, 2f);

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
            else if (Input.GetButtonUp("Fire1")&& WeaponManager.Instance._inBattleSceneWeapon)
            {
                WeaponManager.Instance.CurrentAnimator()?.SetBool("Shoot", false);
                if (isDebug)
                {
                    debugAnim.SetBool("Shoot", false);
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && _timer >= PlayerPalam.Instance.FireInterval)
            {
                if (isDebug)
                {
                    debugAnim.SetTrigger("Shoot");
                }
                else if (WeaponManager.Instance._inBattleSceneWeapon)
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
                    var ef =  Instantiate(_efectprefab, _hit.point, Quaternion.identity);
                    Destroy(ef,2f);

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

    void OpenChest()
    {
        if(_chest && Input.GetKeyDown(KeyCode.E))
        {
            _chest.OpenChest();
            //開けたらチェストのレイヤーをデフォルトに
            _chest.gameObject.layer = default;
            _chest = null;
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

    [SerializeField] Text _startText;
    private void OnTriggerStay(Collider other)
    {      
        if (other.CompareTag("Door"))
        {
            _startText.text = $"[E]ボタンではじまります！";
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.transform.parent.GetComponent<Animator>().SetTrigger("Open");
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            _startText.text = "";
            DOVirtual.DelayedCall(3, () => InBattleSceneManager.Instance.StartTrue()); 
        }
    }

}
