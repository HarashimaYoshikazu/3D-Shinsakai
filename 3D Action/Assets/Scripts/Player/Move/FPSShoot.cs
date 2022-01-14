using UnityEngine;

public class FPSShoot : MonoBehaviour
{
    [SerializeField,Tooltip("FPS のカメラ")]
    Camera m_mainCamera;

    [SerializeField, Tooltip("照準となる UI オブジェクト")] 
    UnityEngine.UI.Image m_crosshair;  

    [SerializeField, Tooltip("照準に敵を捕らえていない時の色")] 
    Color m_noTarget = Color.white;

    [SerializeField, Tooltip("照準に敵を捕らえている時の色")] 
    Color m_onTarget = Color.red;

    [SerializeField, Range(1, 200), Tooltip("射撃可能距離")]
    float m_shootRange = 10f;

    [SerializeField, Tooltip("照準の Ray が当たる Layer")]
    LayerMask m_shootingLayer;

    /// <summary>攻撃したらダメージを与えられる対象</summary>
    DamageableController m_target;

    [SerializeField, Tooltip("攻撃した時に加える力のスカラー量")] 
    float m_shootPower = 50f;

    [SerializeField, Tooltip("射撃音")]
    AudioClip m_shootingSfx;

    [SerializeField, Range(0f,5f), Tooltip("射撃のインターバル")]
    float _initialFireInterval = 0.5f;

    static float _fireInterval ;
    public static float FireInterval => _fireInterval;

   /// <summary>インターバルを計測するタイマー</summary>
    float _timer = 0;

    void Start()
    {
        _fireInterval = _initialFireInterval;
        // マウスカーソルを消す（実行中は ESC キーを押すとマウスカーソルが表示される）
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (!m_mainCamera)
        {
            m_mainCamera = Camera.main;
            if (!m_mainCamera)
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
    /// 照準にダメージを与えられる対象がいる場合に照準の色を変え、その対象を m_target に保存する
    /// </summary>
    void Aim()
    {
        Ray ray = m_mainCamera.ScreenPointToRay(m_crosshair.rectTransform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, m_shootRange, m_shootingLayer))
        {
            m_target = hit.collider.GetComponent<DamageableController>();

            if (m_target)
            {
                m_crosshair.color = m_onTarget;
            }
            else
            {
                m_crosshair.color = m_noTarget;
            }
        }
        else
        {
            m_target = null;
            m_crosshair.color = m_noTarget;
        }
    }

    /// <summary>
    /// 敵を撃つ
    /// </summary>
    private void Shoot()
    {
        if (Input.GetButton("Fire1") && _timer >= _fireInterval)
        {
            if (m_shootingSfx)
            {
                AudioSource.PlayClipAtPoint(m_shootingSfx, this.transform.position);
            }
            if (m_target)
            {   
                m_target.Damage(1);

                Rigidbody rb = m_target.GetComponent<Rigidbody>();
                if (rb)
                {
                    // 斜め上方向に力を加える
                    Vector3 dir = m_target.transform.position - this.transform.position;
                    dir.y = 0;
                    dir = (dir.normalized + Vector3.up).normalized;
                    rb.AddForce(dir * m_shootPower, ForceMode.Impulse);
                }
            }
            _timer = 0f;
        }       
    }
    static public void FireIntervalfluctuation(float value)
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
}
