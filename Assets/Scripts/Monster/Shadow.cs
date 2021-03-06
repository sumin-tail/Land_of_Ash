using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shadow : MonoBehaviour
{
    Rigidbody2D rb;
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;
    //애니메이션
    Animator anim;
    //다음엔 어떻게 움직일 것인지를 담을 변수
    public int nextMove;
    //hp
    int hp;
    //하울링때 날아갈 프리팹
    public GameObject bulletPrefab;
    //폭발생성 프리팹
    public GameObject boomPrefab;
    //바닥에 불 생성
    public GameObject fire;
    //소환할 몬스터 프리팹
    public GameObject [] monster;

    public GameObject traceTarget;
    Vector3 firePos;

    void Awake()
    {
        //어웨이크로 초기화 하는 거 잊지말기
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hp = 500; //500임
    }
    void Start()
    {
        //어웨이크가 무사히 다 끝나고 난 뒤 함수호출
        StartCoroutine(BossThink());
    }

    private void Update()
    {
        GameManager.instance.BossHP.value = hp;
    }

    IEnumerator BossThink()
    {
        nextMove = -2;
        while (hp>0)
        {
            int max = 3;
            if (hp <= 350)
            {
                max = 4;
            }
            else if (hp <= 250)
            {
                max = 5;
            }
            else if (hp <= 150)
            {
                max = 6;
            }
            int think = Random.Range(0, max);

            Vector3 playerpos = Vector3.zero;

            if (traceTarget != null)
            {
                playerpos = traceTarget.transform.position;
            }

            switch (think)
            {
                //이동
                case 0:
                    for (int i = 0; i < 30; i++)
                    {
                        if (traceTarget != null)
                        {
                            playerpos = traceTarget.transform.position;
                        }

                        if (playerpos.x > transform.position.x)
                        {
                            nextMove = 2;
                        }

                        if (playerpos.x < transform.position.x)
                        {
                            nextMove = -2;
                        }
                        anim.SetBool("Move", true);
                        rb.velocity = new Vector2(nextMove, rb.velocity.y);
                        transform.localScale = new Vector3(-nextMove / 2, 1, 1);
                        yield return new WaitForSeconds(0.1f);
                    }
                    break;
                case 1:
                    yield return Howling();
                    yield return new WaitForSeconds(3f);
                    break;
                case 2:
                    if (playerpos.x > transform.position.x)
                    {
                        nextMove = 2;
                    }

                    if (playerpos.x < transform.position.x)
                    {
                        nextMove = -2;
                    }
                    transform.localScale = new Vector3(-nextMove / 2, 1, 1);
                    yield return Rush();
                    yield return new WaitForSeconds(3f);
                    break;
                case 3:
                    SummonsBoom();
                    yield return new WaitForSeconds(3f);
                    break;
                case 4:
                    yield return SummonsFire();
                    yield return new WaitForSeconds(3f);
                    break;
                case 5:
                    SummonsMonster();
                    yield return new WaitForSeconds(3f);
                    break;
                default:
                    break;
            }
            
        }
    }

    void FixedUpdate()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene("BadL");
            Destroy(gameObject);
        }
    }

    IEnumerator Howling()
    {
        //움직이는거 멈춤
        rb.velocity = Vector2.zero;
        anim.SetBool("Move", false);
        anim.SetBool("H", true);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 30; i++)
        {
            //for문으로 총말 만듬 i의 갯수만큼  30개
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = this.transform.position; //보스(자기)위치에서 나가게 하는거
            bullet.transform.eulerAngles = new Vector3(0, 0, i * 12); //돌려서 앞으로 나가게 해줌 eulerAngles이 각도 설정해 주는거 
            //각도는 360도 니까 360나누기 총알갯수 30 해서 12 나옴 i*12 도 해서 12도씩 돌아가있는 총알 생성
        }
        anim.SetBool("H", false);
    }

    IEnumerator Rush()
    {
        anim.SetBool("Move", false);
        anim.SetBool("Run", true);
        yield return new WaitForSeconds(1f);
        rb.velocity = new Vector2(nextMove * 5f, 0f);
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector2.zero;
        anim.SetBool("Run", false);
    }

    void SummonsBoom()
    {
        anim.SetBool("Move", false);
        for (int i = 0; i < 5; i++)
        {
            float x = Random.Range(-10f,10f);
            float y = Random.Range(-1f, 3f);
            GameObject bullet = Instantiate(boomPrefab);
            bullet.transform.position = new Vector3(x, y) + transform.position;
        }
    }

    IEnumerator SummonsFire()
    {
        //움직이는거 멈춤
        rb.velocity = Vector2.zero;
        anim.SetBool("Move", false);
        for (float i = 0; i < 10; i++)
        {
            if (nextMove/2 == -1)
            {
                firePos = transform.position;
                firePos += new Vector3(-1f - (i / 2), -0.5f, 0f);
                Instantiate(fire, firePos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }

            if (nextMove/2 == 1)
            {
                firePos = transform.position;
                firePos += new Vector3(1f + (i / 2), -0.5f, 0f);
                Instantiate(fire, firePos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }

        }
    }

    void SummonsMonster()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject summonsMonster = Instantiate(monster[i]);
            summonsMonster.transform.position = this.transform.position;
        }
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

    //플레이어 위치
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            traceTarget = other.gameObject;
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
