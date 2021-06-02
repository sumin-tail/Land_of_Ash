using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
   
    void Start()
    {
        if (PlayerPrefs.GetInt("Kill") == 0 && PlayerPrefs.GetInt("TotemOn") == 6)
        {
            //진엔딩
            SceneManager.LoadScene("RealEnding");
        }
        else if (PlayerPrefs.GetInt("Kill") == 6 && PlayerPrefs.GetInt("Totem") == 6)
        {
            //배드엔딩
            SceneManager.LoadScene("BadEnding");
        }
        else
        {
            //노말엔딩
            SceneManager.LoadScene("NomalEnding");
        }

    }

}
