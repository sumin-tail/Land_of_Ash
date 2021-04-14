using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHpImage : MonoBehaviour
{
    //이미지를 담을 컴포넌트 image
    private Image image;

    //인스펙터뷰에서 채우기 위해 SerializeField 를 적용시킴
    [SerializeField]
    private Slider sliderHp; //플레이어 Hp 슬라이더 
    [SerializeField]
    private Sprite maxHp; //풀피일때의 이미지
    [SerializeField]
    private Sprite Hp; //풀피가 아닐 때의 이미지


    void Start()
    {
        //게임오브젝트에있는 Image 컴포넌트 가져옴
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (sliderHp.value == 100)
        {
            image.sprite = maxHp;
        }

        if (sliderHp.value < 100)
        {
            image.sprite = Hp;
        }
    }
}
