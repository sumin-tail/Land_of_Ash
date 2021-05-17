using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneButton : MonoBehaviour
{
    public void LoadScene()
    {   //이어하기
        //저장된 키값이 없을경우 튜토리얼로 보냄
        if (PlayerPrefs.HasKey("Secen")==false)
        {
            PlayerPrefs.SetInt("Secen", 1);
            PlayerPrefs.SetInt("PlayerAtk", 2);
            PlayerPrefs.SetInt("Kill", 0);
            PlayerPrefs.SetInt("Totem", 0);
            SceneManager.LoadScene(1);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("Secen"));
    }
}
