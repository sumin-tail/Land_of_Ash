using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineMonster1 : MonoBehaviour
{
    //콜라이더 사이즈 변경용
    public BoxCollider2D monster;
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;

    //시간지연용
    float time;
    float waitingTime;

    //몬스터 hp
    int hp;
    //플레이어 서칭
    bool find;

    //애니메이션
    Animator anim;

    private void Awake()
    {
        monster = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //애니메이터 가져옴
        anim = GetComponent<Animator>();
        hp = 10;
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

        if (time > waitingTime && find)
        {
            Attack();
            time = 0f;
        }

        if (hp <= 0)
        {
            GameManager.instance.killCount++;
            Destroy(gameObject);
        }

    }

    //플레이어가 인식범위 안으로 들어옴
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            find = true;
            anim.SetBool("Find", true);
        }
    }

    //플레이어가 인식범위 밖으로 나감
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            find = false;
            anim.SetBool("Find", false);
            Stay();
        }
    }

    //플레이어의 총에 맞음
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

    //크기변경/공격
    void Attack()
    {
        monster.size = new Vector2(0.6f, 1.3f);
    }

    void Stay()
    {
        monster.size = new Vector2(0.3f, 1.3f);
    }

}
