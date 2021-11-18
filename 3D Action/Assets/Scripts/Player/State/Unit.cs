using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]int _hp  =10;
    [SerializeField] CardManager _cardManager;
    public int Hp { get => _hp; set => _hp = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp<=0)
        {
            Debug.Log(_hp + "しんだ");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _hp -= 5;
            Debug.Log(_hp);
        }
    }

    void Dead()
    {
        int ran = Random.Range(0, _cardManager.AllCards.Length);
        CardManager.InventriCards.Add(_cardManager.AllCards[ran]);
    }
}
