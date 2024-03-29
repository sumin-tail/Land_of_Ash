﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHpImage : MonoBehaviour
{
    //이미지를 담을 컴포넌트 image
    private Image image;
    public Sprite maxHp; //풀피일때의 이미지
    public Sprite Hp; //풀피가 아닐 때의 이미지

    void Start()
    {
        //게임오브젝트에있는 Image 컴포넌트 가져옴
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (GameManager.instance.playerHp.value == 100)
        {
            image.sprite = maxHp;
        }

        if (GameManager.instance.playerHp.value < 100)
        {
            image.sprite = Hp;
        }
    }
}
