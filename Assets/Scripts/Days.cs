using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Days : MonoBehaviour
{
    public Text DayText;  //날짜 텍스트
    static int month = 1;  //월

    void Update()
    {
        if(PlayerPrefs.GetInt("운동하기")==1 && PlayerPrefs.GetInt("식단하기")==1 && PlayerPrefs.GetInt("공부하기")==1){  //미니게임을 3번 하면 한달 지남
            //다시 초기화
            PlayerPrefs.SetInt("운동하기",0);
            PlayerPrefs.SetInt("식단하기",0);
            PlayerPrefs.SetInt("공부하기",0);
            month += 1;  //날짜 증가
        }
        DayText.text = "날짜: " + month + "월";  //날짜 텍스트 설정
    }
}
