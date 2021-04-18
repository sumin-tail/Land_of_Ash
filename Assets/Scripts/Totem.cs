using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Totem : MonoBehaviour
{
    //이미지를 담을 컴포넌트 image
    SpriteRenderer spriteRenderer;
    public Sprite destroy; //파괴 이미지를 담을 Sprite 변수 선언

    void Start()
    {
        //게임오브젝트에있는 SpriteRenderer 컴포넌트 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //키보드 Z 키를 누르고 있을 경우 > 누를 경우는 겟 키 다운임
        if (Input.GetKey(KeyCode.Z))
        {
            //파괴 이미지로 변경
            spriteRenderer.sprite = destroy;
        }
    }

}
