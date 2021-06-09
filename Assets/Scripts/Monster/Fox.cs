using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Rigidbody2D rb;
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;
    AudioSource ads;
    //애니메이션
    Animator anim;
    //다음엔 어떻게 움직일 것인지를 담을 변수
    public int nextMove;
    //hp
    int hp;

    void Awake()
    {
        //어웨이크로 초기화 하는 거 잊지말기
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ads = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hp = 30;
    }
    void Start()
    {
        //어웨이크가 무사히 다 끝나고 난 뒤 함수호출
        NextMove();
    }

    void FixedUpdate()
    {
        //움직이는 방향에 따라 이동하는 거
        rb.velocity = new Vector2(nextMove, rb.velocity.y);

        //지형체크용
        Vector2 check = new Vector2(rb.position.x + nextMove * 0.3f, rb.position.y);
        //유니티 화면내에서 레이를 확인하려고 쓴 코드임-지워도 상관없음
        Debug.DrawRay(check, Vector3.down, new Color(1, 0, 0));
        //레이캐스트 힛
        RaycastHit2D ray = Physics2D.Raycast(check, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (ray.collider == null)
        {
            nextMove *= -1;
            //현재 작동중인 Invoke함수 모두 정지
            CancelInvoke();
            //정지시켰으니 재실행
            Invoke("NextMove", 3);
        }

        //작업이미지가 플레이어와 반대 방향이라 nextMove 앞에-를 붙인것임!!!
        //이건 움직이는 방향에 따라 이미지가 뒤집히도록 하는 것
        if (nextMove == 0)
        {
            anim.SetBool("Move", false);
        }
        else
        {
            transform.localScale = new Vector3(-nextMove, 1, 1);
            anim.SetBool("Move", true);
        }

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

    void NextMove()
    {
        //난수로 어느 방향으로 움직일 것인지 설정
        nextMove = Random.Range(-1, 2);

        //일정 시간뒤에 다음 함수를 호출 
        Invoke("NextMove", 3);
    }

    //플레이어의 총에 맞거나 플레이어와 충돌했을 때
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            OnDamage();
        }

        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.PlayerHP(10f);
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
