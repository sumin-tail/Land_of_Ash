﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //스피드랑 점프 스케일 적용하기
    public float speed = 4f;
    public float jump = 15f;
    public GameManager gameManager;
    //리지드 바디 설정
    Rigidbody2D rb;
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;


    void Awake()
    {
        //해당되는 게임 컴포넌트의 리지드 바디를 가져옴
        rb = GetComponent<Rigidbody2D>();
        //렌더 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveMent();
    }

    void MoveMent()
    {
        //좌우이동. GetAxis는 -1.0f 부터 1.0f 까지의 범위의 값을 반환 > 아래에서 부드러운 이동용으로 사용
        //0에서 좌이동일경우 -1.0f로 우이동일 경우 1.0f로 올라감 
        float HorizontalMove = Input.GetAxis("Horizontal");
        //플레이어 이미지 방향 GetAxisRaw는 -1, 0, 1 세 가지 값 중 하나가 반환. 즉각적인 반응에 사용
        float FaceDircetion = Input.GetAxisRaw("Horizontal");

        if (HorizontalMove != 0)
        {
            //천천히 플레이어 속도를 4f또는 -4f 까지 올림
            rb.velocity = new Vector2(HorizontalMove * speed, rb.velocity.y);
        }

        if (FaceDircetion != 0)
        {
            transform.localScale = new Vector3(FaceDircetion, 1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }

    //에너미 충돌 체크
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnDamage();
        }
    }

    //무적상태
    void OnDamage()
    {
        gameManager.sliderHp.value -= 10f;    
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffDamage", 1);
    }
    //무적상태 해제
    void OffDamage()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
