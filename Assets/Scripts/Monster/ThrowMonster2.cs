﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMonster2 : MonoBehaviour
{
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;
    AudioSource ads;
    public GameObject bullet;
    //a몬스터 총알 위치 설정
    Vector3 bulletPos;

    //시간지연용
    float time;
    float waitingTime;

    //몬스터 hp
    int hp;
    //플레이어 서칭
    bool find;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ads = GetComponent<AudioSource>();
        hp = 10;
        bulletPos = transform.position;
        bulletPos += new Vector3(0f, 0f, -1f);
    }
    private void Start()
    {
        time = 0f;
        waitingTime = 2f;
        find = false;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time > waitingTime&&find)
        {
            for (int i = 0; i < 12; i++)
            {
                Instantiate(bullet, bulletPos, Quaternion.Euler(new Vector3(0, 0, i * -30)));
            }
            time = 0f;
        }

        if (hp<=0)
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

    //플레이어가 인식범위 안으로 들어옴
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            find = true;
        }
    }
    //플레이어가 인식범위 밖으로 나감
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            find = false;
        }
    }
    //플레이어의 총에 맞음
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            OnDamage();
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
