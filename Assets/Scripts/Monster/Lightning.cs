using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //플레이어가 무적레이어가 아니고 닿았을경우
        if (other.tag == "Player" && other.gameObject.layer == 10)
        {
            GameManager.instance.PlayerHP(10f);
        }
    }
}
