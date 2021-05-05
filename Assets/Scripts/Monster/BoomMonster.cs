using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomMonster : MonoBehaviour
{
    //콜라이더 사이즈 변경용
    public CapsuleCollider2D boom;
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        boom = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //닿으면 한번 실행 됨
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //1초 뒤에 폭발
            Invoke("Boom", 1f);
            StartCoroutine("BoomColor");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            GameManager.instance.PlayerHP(10f);
        }
    }

    IEnumerator BoomColor()
    {
        for (float i = 0; i < 0.5f; i += 0.1f)
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }

    }

    void Boom()
    {
        boom.size = new Vector2(1f, 0.4f);
        Destroy(gameObject, 0.1f);
    }

}
