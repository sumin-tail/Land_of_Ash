using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //콜라이더 사이즈 변경용
    public CapsuleCollider2D fire;
    //애니메이션
    Animator anim;

    private void Awake()
    {
        fire = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        Invoke("Burn", 1f);
    }

    void Burn()
    {
        anim.SetBool("Burn", true);
        fire.size = new Vector2(0.3f, 1f);
        Destroy(gameObject, 0.2f);
    }
}
