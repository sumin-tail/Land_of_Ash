using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public void LoadScene()
    {
        //게임 시작 버튼(리셋)
        //Button 누르면 게임을 시작
        //게임진행도 데이터 초기화
        PlayerPrefs.SetInt("Secen", 1);
        PlayerPrefs.SetInt("PlayerAtk", 2);
        PlayerPrefs.SetInt("Kill", 0);
        PlayerPrefs.SetInt("Totem", 0);
        SceneManager.LoadScene(1);
    }
}
