using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //스피드랑 점프 스케일 적용하기
    public float speed = 3f;
    public Rigidbody2D rb;
    public float jump = 10f;

    void Update()
    {
        MoveMent();
    }
    void MoveMent()
    {
        float HorizontalMove = Input.GetAxis("Horizontal");
        float FaceDircetion = Input.GetAxisRaw("Horizontal");

        if (HorizontalMove != 0)
        {
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
}
