using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnding : MonoBehaviour
{
    private void Start()
    {
        Invoke("Restart", 5f);
    
    }

    void Restart()
    {
        SceneManager.LoadScene("Start");
    }
}
