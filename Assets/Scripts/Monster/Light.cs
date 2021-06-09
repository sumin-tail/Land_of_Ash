using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Light : MonoBehaviour
{
    Rigidbody2D rb;
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;
    //애니메이션
    Animator anim;
    //hp
    int hp;

    //폭발생성 프리팹
    public GameObject boomPrefab;
    //총
    public GameObject gun;
    //창
    public GameObject spear;
    //낙뢰
    public GameObject lightning;

    public GameObject god;

    void Awake()
    {
        //어웨이크로 초기화 하는 거 잊지말기
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hp = 700; //700
    }
    void Start()
    {
        //어웨이크가 무사히 다 끝나고 난 뒤 함수호출
        StartCoroutine(BossThink());
    }

    IEnumerator BossThink()
    {
        while (hp>0)
        {
            int max = 2;

            if (hp <= 490) //70퍼
            {
                max = 4;
            }
            else if (hp <= 350) //50퍼
            {
                max = 5;
            }
            else if (hp <= 210) //30퍼
            {
                max = 6;
            }
            int think = Random.Range(0, max);


            switch (think)
            {
                case 0:
                    yield return Lightning();
                    break;
                case 1:
                    SummonsGun();
                    break;
                case 2:
                    SummonsBoom();
                    break;
                case 3:
                    //공격반사
                    yield return reflect();
                    break;
                case 4:
                    //즉사
                    yield return InstantDeath();
                    break;
                case 5:
                    yield return SummonsSpear();
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(3f);
        }
    }

    //낙뢰생성 - 가로
    IEnumerator Lightning()
    {
        //배열 생성
        GameObject[] lightnings = new GameObject[9];
        Vector3 lightningPos = new Vector3 (-15,3,0);

        for (int i = 0; i < 9; i++)
        {
            lightnings[i] = Instantiate(lightning, lightningPos, Quaternion.identity);
            lightningPos.x += 2;
        }
        //2초 대기
        yield return new WaitForSeconds(2f);
        //콜라이더 켬
        for (int i = 0; i < 9; i++)
        {
            var col = lightnings[i].GetComponent<CapsuleCollider2D>();
            col.enabled = true;
        }
        //한 프레임 대기
        yield return new WaitForEndOfFrame();

        //모두 삭제
        for (int i = 0; i < 9; i++)
        {
            Destroy(lightnings[i]);
        }
    }

    //총 생성-세로
    void SummonsGun()
    {
        GameObject[] lightnings = new GameObject[5];
        Vector3 lightningPos = new Vector3(-1, 7, 0);
        for (int i = 0; i < 5; i++)
        {
            lightnings[i] = Instantiate(lightning, lightningPos, Quaternion.identity);
            lightningPos.y -= 2;
        }
    }

    //창생성 - 플레이어 머리위에 
    IEnumerator SummonsSpear()
    {
        for (int i = 0; i < 4; i++)
        {
            var p = GameObject.FindGameObjectWithTag("Player").transform.position;
            p.x += 1f;
            p.y += 1f;
            Instantiate(spear, p, Quaternion.Euler(0,0,135));
            yield return new WaitForSeconds(0.3f);
        }

    }

    //공격반사
    IEnumerator reflect()
    {
        tag = "Reflector";
        yield return new WaitForSeconds(3f);
        tag = "Enemy";
    }

    //즉사 공격
    IEnumerator InstantDeath()
    {
        var g = Instantiate(god, new Vector3(-6,-1,0), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        var p = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (p.x<-4 || p.x > -2 || p.y < -2 || p.y > 0)
        {
            GameManager.instance.PlayerHP(100f);
        }
        yield return new WaitForSeconds(0.3f);
        Destroy(g);
    }

    void FixedUpdate()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene("RealL");
            Destroy(gameObject);
        }
    }

    void SummonsBoom()
    {
        for (int i = 0; i < 5; i++)
        {
            float x = Random.Range(-10f,10f);
            float y = Random.Range(-1f, 3f);
            GameObject bullet = Instantiate(boomPrefab);
            bullet.transform.position = new Vector3(x, y) + transform.position;
        }
    }

    //플레이어의 총에 맞거나 플레이어와 충돌했을 때
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if(tag != "Reflector")
            {
                OnDamage();
            }
            else
            {
                //플레이어 데미지 만큼 데미지 줌
                GameManager.instance.PlayerHP(GameManager.instance.playerAtk);
            }
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
