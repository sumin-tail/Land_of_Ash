using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    //콜라이더 사이즈 변경용
    public CircleCollider2D boom;
    AudioSource ads;
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        boom = GetComponent<CircleCollider2D>();
        ads = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        StartCoroutine("BoomThink");
    }

    IEnumerator BoomThink()
    {
        for (int i = 0; i < 5; i += 1)
        {
            transform.localScale = Vector3.one * 1.2f;
            yield return new WaitForSeconds(0.2f);
            transform.localScale = Vector3.one;
            yield return new WaitForSeconds(0.2f);
        }
        boom.radius = 0.4f;
        ads.Play();
        Destroy(gameObject, 0.2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.PlayerHP(20f);
        }
    }

}
