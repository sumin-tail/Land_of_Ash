using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTotemBrake : MonoBehaviour
{
    //이미지를 담을 컴포넌트 image
    private Image image;
    public Sprite totemBrake; //킬을 일정횟수 이상 했을 경우 이미지 변경을 위해
    void Start()
    {
        //게임오브젝트에있는 Image 컴포넌트 가져옴
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (GameManager.instance.TotemBrake)
        {
            image.sprite = totemBrake;
        }
    }
}
