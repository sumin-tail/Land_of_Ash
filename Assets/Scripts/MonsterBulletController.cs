using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBulletController : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //2초 뒤에 파괴
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(0.01f, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //플레이어랑 닿으면 사라짐
            Destroy(gameObject);
        }
    }
}
