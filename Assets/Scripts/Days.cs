using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Days : MonoBehaviour
{
    public Text DayText;  //날짜 텍스트
    static int month = 1;  //월
    static int gameCount = 2;  //게임횟수

    void Update()
    {
        gameCount = PlayerPrefs.GetInt("게임횟수");
        if(gameCount == 5){  //미니게임을 3번 하면 한달 지남
            gameCount = 2;//게임 횟수 다시 초기화
            //(왜인지 모르겠으나 처음 횟수가 2로 시작되기 때문에 횟수 맞추려면 어쩔수없이 2로 초기화 해야함...)
            month += 1;  //날짜 증가
            PlayerPrefs.SetInt("게임횟수",gameCount);
        }
        DayText.text = "날짜: " + month + "월";  //날짜 텍스트 설정
    }
}
