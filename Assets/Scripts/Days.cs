using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Days : MonoBehaviour
{
    public Text DayText;  //날짜 텍스트
    static int month = 1;  //월
    void Update()
    {
        if(PlayerPrefs.GetString("운동하기버튼").Equals("비활성화") && PlayerPrefs.GetString("식단하기버튼").Equals("비활성화") && PlayerPrefs.GetString("공부하기버튼").Equals("비활성화")){  //미니게임을 3번 하면 한달 지남
            //다시 초기화
            Debug.Log("한달지남");
            PlayerPrefs.SetString("운동하기버튼","활성화");
            PlayerPrefs.SetString("공부하기버튼","활성화");
            PlayerPrefs.SetString("식단하기버튼","활성화");
            month += 1;  //날짜 증가
        }
        DayText.text = "날짜: " + month + "월";  //날짜 텍스트 설정
        if(month == 6){  //6월이 되면 몇 레벨인지 체크함 
            LastCheck();
        }
    }
    private void LastCheck()  //5단계에 도달했는가
    {
        //레벨이 0부터 시작임
        if(PlayerPrefs.GetInt("레벨") == 4){  //레벨이 5면 해피엔딩으로
            SceneManager.LoadScene("HappyEndingScene");
        }
        else if(PlayerPrefs.GetInt("레벨") < 4){  //레벨이 5가 안되면 배드엔딩으로
            SceneManager.LoadScene("BadEndingScene");
        }
    }
}
