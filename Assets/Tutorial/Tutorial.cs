using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject img;

    //OnTriggerStay2D는 Collider2D가 닿아있는동안 계속 실행이 됨
    void OnTriggerStay2D(Collider2D other)
    {
        //부딫히고있는 물체가 Player 태그를 달고있고 키보드 Z 키를 누르고 있을 경우 
        if (other.tag == "Player" && Input.GetKey(KeyCode.Z))
        {
            img.SetActive(true);
            Invoke("Destroy", 1f);
        }
    }

    void Destroy()
    {
        img.SetActive(false);
    }
}
