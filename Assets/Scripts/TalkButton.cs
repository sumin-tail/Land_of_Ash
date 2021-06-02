using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject talkUI;
    public bool touch;

    //test
    public bool talked = true;

    private void Start()
    {
        touch = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touch = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touch = false;
        }
    }
    void Update()
    {
        /* if (touch && Input.GetKeyDown(KeyCode.Z))
         {
             talkUI.SetActive(true);
         }
        */

        //test
        if (talked && touch && Input.GetKeyDown(KeyCode.Z))
        {
            talkUI.SetActive(true);
            talked = false;
        }
    }
}
