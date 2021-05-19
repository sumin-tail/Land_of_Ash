using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowText : MonoBehaviour
{
    public GameObject crowTalk;
    public GameObject playerTalk;

    //플레이어가 인식범위 안으로 들어옴
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            crowTalk.SetActive(true);
            playerTalk.SetActive(true);
        }
    }

    //플레이어가 인식범위 밖으로 나감
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            crowTalk.SetActive(false);
            playerTalk.SetActive(false);
        }
    }

}
