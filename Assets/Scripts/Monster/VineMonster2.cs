using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineMonster2 : MonoBehaviour
{
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;
    AudioSource ads;
    //몬스터 hp
    int hp;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ads = GetComponent<AudioSource>();
        hp = 10;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            if (ads.isPlaying == false)
            {
                GameManager.instance.killCount++;
                ads.Play();
                Destroy(gameObject, 1f);
                spriteRenderer.enabled = false;
                tag = "Untagged";
            }
        }
    }


    //플레이어의 총에 맞거나 플레이어와 닿음
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            OnDamage();
        }

        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.PlayerHP(7f);
        }

    }

    void OnDamage()
    {
        hp -= GameManager.instance.playerAtk;
        GameManager.instance.playerHp.value += GameManager.instance.playerAtk;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffDamage", 0.1f);
    }

    void OffDamage()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

}
