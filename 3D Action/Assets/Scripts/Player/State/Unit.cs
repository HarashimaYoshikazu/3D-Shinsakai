using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]int _hp  =10;
    [SerializeField] CardManager _cardManager;
    [SerializeField] int _getGold =5;
    public int Hp { get => _hp; set => _hp = value; }
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0  )
        {            
            Dead();
            Debug.Log(_hp + "しんだ");
            Debug.Log(CardManager.InventriCards[0]);
            Debug.Log("お金　＝" +PlayerStateManager.Gold);
            isDead = true;
        }
        if (isDead)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _hp -= PlayerStateManager.Attack;
            Debug.Log(_hp);
        }
    }

    void Dead()
    {
        //インベントリにランダムなカードを追加
        int ran = Random.Range(0, _cardManager.AllCards.Length);
        CardManager.InventriCards.Add(_cardManager.AllCards[ran]);
        //お金、経験値を追加
        PlayerStateManager.Gold += _getGold;
        //死ぬアニメーションを再生       
        //ターゲットをDefaultに戻す
        ColiderGet.Nearbyobject = GameObject.Find("defaultCol").GetComponent<Collider>();
    }
}
