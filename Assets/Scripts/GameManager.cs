using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //게임매니저를 싱글톤으로 만들어줌.
    public static GameManager instance = null;
    public Slider playerHp; //플레이어 Hp바
    public int playerAtk;//플레이어 공격력
    public int killCount;//킬 카운트
    public bool TotemBrake = false;
    public bool TotemOn = false;
    // 토템 킨 갯수/부순 토템갯수/학살을 완료한 수
    void Awake()
    {
        if (instance == null)
        {
            //instance 에 자신이 담겨있지 않다면 자신을 넣어줌
            instance = this;
        }
        else
        {
            if (instance != this) 
            {
                //instance에 이미 게임오브젝트가 담겨있다면 새로운 씬의 GameManager를 삭제함.
                Destroy(this.gameObject);
            }    
        }
    }

    //사용방법은 GameManager.instance.~~ 로 사용하면 된다.
    private void Start()
    {
        //플레이어 공격력 초기화
        playerAtk = PlayerPrefs.GetInt("PlayerAtk");
        killCount = 0;


        Debug.Log("플레이어 공격력" + PlayerPrefs.GetInt("PlayerAtk"));
        Debug.Log("킬카운트 " + PlayerPrefs.GetInt("Kill"));
        Debug.Log("토템"+PlayerPrefs.GetInt("Totem"));
    }

    private void Update()
    {
       //플레이어 hp가 0이하일경우 현재씬을 재실행
        if (playerHp.value <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //플레이어 HP관리용
    public void PlayerHP(float Dam)
    {
        playerHp.value -= Dam;
    }
}
