using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderGet : MonoBehaviour
{
    [SerializeField]float _radius = 5f;
    static Collider nearbyobject ;
    public static Collider Nearbyobject { get => nearbyobject; set => nearbyobject = value; }

    private void Awake()
    {
        nearbyobject = GameObject.Find("defaultCol").GetComponent<Collider>();
    }
    public void GetEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position,_radius);
        foreach (Collider enemy in colliders)
        {
            //敵のコライダーとってくる
            if (enemy.tag =="enemy")
            {
                //色つけたい
                nearbyobject = enemy;
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
