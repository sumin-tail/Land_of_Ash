using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBulletController : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -3;
        //2초 뒤에 파괴
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //플레이어가 무적레이어가 아니고 닿았을경우
        if (other.tag == "Player" && other.gameObject.layer == 10)
        {
            GameManager.instance.PlayerHP(5f);
            Destroy(gameObject);
        }
        if (other.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }

}
