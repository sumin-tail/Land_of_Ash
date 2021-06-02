using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTotem : MonoBehaviour
{
    //spriteRenderer를 담을 컴포넌트
    SpriteRenderer spriteRenderer;
    public Sprite on; //on 이미지를 담을 Sprite 변수
    public int onTotem = 0; //토템이 on 상태인지 아닌지 확인용

    void Start()
    {
        //게임오브젝트에있는 SpriteRenderer 컴포넌트 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //부딪히고있는 물체가 Player 태그를 달고있고 키보드 Z 키를 눌렀으며 토템이 on 상태가 아닐때 
        if (other.tag == "Player" && Input.GetKey(KeyCode.Z) && onTotem!=1)
        {
            onTotem = 1;
            spriteRenderer.sprite = on;
            StartCoroutine("OnTotemColor");
            GameManager.instance.TotemOn = true;
        }
    }

    //코루틴을 사용해서 서서히 밝아지는 효과 표현 
    IEnumerator OnTotemColor()
    {
        for (float i = 0; i < 1f; i += 0.1f)
        {
            spriteRenderer.color = new Color(i, i, i, 1);
            yield return new WaitForSeconds(0.1f);
        }

    }

}
