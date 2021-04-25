using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour
{
    //스피드랑 점프 스케일 적용하기
    public float speed = 5f;
    public float jumpForce = 15f;

    //점프
    public LayerMask theGround;
    public Transform groundCheck;
    public bool onTheGround = false;

    //애니메이터
    Animator anim;

    //리지드 바디 설정
    Rigidbody2D rb;
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        //해당되는 게임 컴포넌트의 리지드 바디를 가져옴
        rb = GetComponent<Rigidbody2D>();
        //게임 컴포넌트의 렌더 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();
        //애니메이터 가져옴
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //점프
        onTheGround = Physics2D.Linecast(transform.position, groundCheck.position, theGround);
        if (onTheGround == true && Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void LateUpdate()
    {
        //이동
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
        //애니메이션
        if (HorizontalMove == 0)
        {
            anim.SetBool("TutorialRun", false);
        }
        else
        {
            anim.SetBool("TutorialRun", true);
        }
    }

}
