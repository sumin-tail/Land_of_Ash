using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealEnding : MonoBehaviour
{
    //스프라이트 렌더 설정
    SpriteRenderer spriteRenderer;
    public Sprite [] im;
    private void Awake()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SpriteChange());
    }

    IEnumerator SpriteChange()
    {
        for (int i = 0; i < 4; i++)
        {
            spriteRenderer.sprite = im[i];
            yield return new WaitForSeconds(1.5f);
        }

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Start");      
    }
}
