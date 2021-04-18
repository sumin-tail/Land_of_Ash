using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //게임매니저를 싱글톤으로 만들어줌.
    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            //instance 에 자신이 담겨있지 않다면 자신을 넣어줌
            instance = this;
            //씬이 바뀌더라도 파괴되지 않게 하는 함수
            DontDestroyOnLoad(this.gameObject);
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

    public Slider playerHp; //플레이어 Hp바
    public Text killCount; //킬 카운트
    public int playerAtk; //플레이어 공격력
}
