using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Totem : MonoBehaviour
{
    //spriteRenderer를 담을 컴포넌트
    SpriteRenderer spriteRenderer;
    public Sprite destroy; //파괴 이미지를 담을 Sprite 변수 선언
    int destroyCount=0;

    void Start()
    {
        //게임오브젝트에있는 SpriteRenderer 컴포넌트 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (destroyCount >= 5 && GameManager.instance.TotemBrake == false)
        {
            TotemDestroy();
        }
    }

    //OnTriggerEnter2D는 Collider2D가 닿을때 한번 실행됨
    void OnTriggerEnter2D(Collider2D other)
    {
        //부딫힌 물체가 Bullet 태그
        if (other.tag == "Bullet")
        {
            destroyCount++;
            OnDamage();      
        }
    }

    //피격 그래픽 변경
    void OnDamage()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffDamage", 0.1f);
    }
    //피격 그래픽 복귀
    void OffDamage()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void TotemDestroy()
    {
        //토템이 부서짐
        GameManager.instance.TotemBrake = true;
        //파괴 이미지로 변경
        spriteRenderer.sprite = destroy;
        //플레이어 공격력 상승
        GameManager.instance.playerAtk++;
        Debug.Log(GameManager.instance.playerAtk);
    }
}
