using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GaugeBarSet : MonoBehaviour
{
    public Image GaugeBarImage;  //게이지 이미지
    static float Gauge;  //게이지 양 저장 변수
    string grade;  //등급


    private void Update() {
        //게임 종료가 되면 값을 받아와 게이지바를 채움
        if(PlayerPrefs.GetString("게임실행여부").Equals("게임종료")){
            grade = PlayerPrefs.GetString("등급");
            PlayerPrefs.SetInt("게임횟수",(PlayerPrefs.GetInt("게임횟수")+1));  //게임횟수 세기
            Debug.Log(PlayerPrefs.GetInt("게임횟수"));
            GaugeFill(grade);
            PlayerPrefs.SetString("게임실행여부","게임실행");
        }
    }
    public void GaugeFill(string grade)  //등급별로 게이지바 채우기
    {
        float amount = 0;
        switch(grade){
            case "A" :amount = 0.1f; break;
            case "B" : amount = 0.08f; break;
            case "C" : amount = 0.05f; break;
            case "D" : amount = 0.03f; break;
        }
        Gauge += amount;
        GaugeBarImage.fillAmount = Gauge; 
        Debug.Log("게이지 채움");
    }
}
