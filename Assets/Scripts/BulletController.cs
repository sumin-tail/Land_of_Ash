using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //왼쪽 총알은 유니티에서 -5f로 변경하기
    public float velX = 5f;
    float velY = 0;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //2초 뒤에 파괴
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    //OnTriggerEnter2D는 Collider2D가 닿을때 한번 실행됨
    void OnTriggerEnter2D(Collider2D other)
    {
        //부딫힌 물체가 Totem 태그
        if (other.tag == "Totem")
        {
            Destroy(gameObject);
        }
    }

    //이건 콜라이즌 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }

 }
