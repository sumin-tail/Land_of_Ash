using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneButton : MonoBehaviour
{
    public void LoadScene()
    {//Menu 돌아가기
        SceneManager.LoadScene(0);
    }
}
