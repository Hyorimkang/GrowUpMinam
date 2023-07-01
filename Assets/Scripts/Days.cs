using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Days : MonoBehaviour
{
    public Text DayText;  //날짜 텍스트
    static int month = 1;  //월
    int gameCount = 0;  //게임횟수

    void Start()
    {
        gameCount = PlayerPrefs.GetInt("게임횟수");
    }

    void Update()
    {
        if(gameCount == 3){  //만약 미니게임을 3번 했다면 한달 지남
            gameCount = 0;//게임 횟수 다시 초기화
            month += 1;  //날짜 증가
            PlayerPrefs.SetInt("게임횟수",gameCount);
        }
        DayText.text = "날짜: " + month + "월";  //날짜 텍스트 설정
    }
}
