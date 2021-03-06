using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{
    //씬을 담을 변수
    Scene scene;
    //현재씬 번호를 담을 변수
    int countScene;
    //다음씬의 번호를 담을 변수
    int nextScene;

    void Awake()
    {
        //scene변수에 씬의 정보을 넣어줌
        scene = SceneManager.GetActiveScene();
        //씬의 빌드 인덱스(빌드 숫자)를 넣어줌.
        countScene = scene.buildIndex;
        //nextScene에 현재씬의 빌드 숫자+1
        nextScene = countScene + 1;
    }

    //OnTriggerStay2D는 Collider2D가 닿아있는동안 계속 실행이 됨
    void OnTriggerStay2D(Collider2D other)
    {
        //부딫히고있는 물체가 Player 태그를 달고있고 키보드 Z 키를 누르고 있을 경우 
        if (other.tag == "Player" && Input.GetKey(KeyCode.Z))
        {
            //다음씬 번호 저장함
            PlayerPrefs.SetInt("Secen", nextScene);

            //플레이어 공격력 저장함
            PlayerPrefs.SetInt("PlayerAtk", GameManager.instance.playerAtk);

            //조건이 맞을경우 저장갱신
            if (GameManager.instance.killCount>=2) // 2로 해놓음 나중에 10으로 바꿀것
            {
                PlayerPrefs.SetInt("Kill", PlayerPrefs.GetInt("Kill")+1);
            }

            if (GameManager.instance.TotemBrake)
            {
                PlayerPrefs.SetInt("Totem", PlayerPrefs.GetInt("Totem") + 1);
            }

            if (GameManager.instance.TotemOn)
            {
                PlayerPrefs.SetInt("TotemOn", PlayerPrefs.GetInt("TotemOn") + 1);
            }

            //다음씬(숫자)로 이동함
            SceneManager.LoadScene(nextScene);
        }
    }

}
