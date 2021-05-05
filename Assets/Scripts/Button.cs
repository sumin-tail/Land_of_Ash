using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public void LoadScene()
    {
        //Button누리면 게임을 시작
        SceneManager.LoadScene(1);
    }
}
