using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static int a= 0;
    [SerializeField,Header("エネミーの情報"),Tooltip("エネミーHP")]int _hp  =10;
    public int Hp { get => _hp; set => _hp = value; }
    [SerializeField, Tooltip("ドロップするゴールド")] 
    int _getGold = 5;
    [SerializeField,Header("コンポーネント"), Tooltip("カードマネージャー")]
    CardManager _cardManager;

    bool isDead = false;
    static　GameObject _dropCard;
    public GameObject DropCard { get => _dropCard; set => _dropCard = value; }

    void Start()
    {
        int ran = Random.Range(0, _cardManager.AllCards.Length);
        _dropCard = _cardManager.AllCards[ran];
    }

    void Update()
    {
        if (Hp <= 0  )
        {            
            Dead();
            Debug.Log(_hp + "しんだ");
            Debug.Log(CardManager.Instance.InventriCards[0]);
            Debug.Log("お金　＝" + PlayerPalam.Instance.Gold);
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
            _hp -= PlayerPalam.Instance.Attack;
            Debug.Log(_hp);
        }
    }

    void Dead()
    {
        //インベントリにランダムなカードを追加
        CardManager.Instance.AddCard(_dropCard);
        //CardBaseに現在のIndexを保存しておく
        CardBase cb = CardManager.Instance.InventriCards[CardManager.Instance.InventriCards.Count - 1].gameObject.GetComponent<CardBase>();
        //カードインデックスの設定
        cb.CardIndex = CardManager.Instance.InventriCards.Count - 1;
        Debug.Log("カードインデックスは" + cb.CardIndex);
        //お金、経験値を追加
        PlayerPalam.Instance.Goldfluctuation(_getGold) ;
        //死ぬアニメーションを再生       
        //ターゲットをDefaultに戻す
        ColiderGet.Nearbyobject = GameObject.Find("defaultCol").GetComponent<Collider>();
    }
}
