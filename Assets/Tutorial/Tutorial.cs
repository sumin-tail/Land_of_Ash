using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject img;
    public GameObject backimg;
    public GameObject lightmon;

    //test
    public bool talked = true;

    //OnTriggerStay2D는 Collider2D가 닿아있는동안 계속 실행이 됨
    void OnTriggerStay2D(Collider2D other)
    {
        //test
        if (other.tag == "Player" && Input.GetKey(KeyCode.Z) && talked == true)
        {
            img.SetActive(true);
            backimg.SetActive(true);
            lightmon.SetActive(true);
            Invoke("Destroy", 1f);
            talked = false;
        }
    }

    void Destroy()
    {
        Destroy(img);
        Destroy(backimg);
        Destroy(gameObject);
        //img.SetActive(false);
        //backimg.SetActive(false);
    }
}
