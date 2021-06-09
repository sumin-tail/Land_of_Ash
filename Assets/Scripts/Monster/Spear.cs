using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Invoke("Ax", 1f);
        Destroy(gameObject, 4f);
    }

   void Ax()
    {
        rb.velocity = new Vector2(0,5);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //플레이어가 무적레이어가 아니고 닿았을경우
        if (other.tag == "Player" && other.gameObject.layer == 10)
        {
            GameManager.instance.PlayerHP(20f);
            Destroy(gameObject);
        }
    }
}
