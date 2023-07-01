using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSet : MonoBehaviour
{
    public Quiz quiz;
    public Text timerTxt;  //시간 출력
    public float time = 10f; //제한 시간
    private float selectCountDown; //카운트 다운
    //bool PlayCheck = false;  //게임시작 했는지 안했는지


    // Update is called once per frame
    public void timer()
    {
        selectCountDown = time;
        //문제 수가 더이상 없을 때까지 타이머 운행
        if(quiz.QnA.Count==0){
            selectCountDown=0;
            timerTxt.text = Mathf.Floor(selectCountDown).ToString();
        }
        else{
            selectCountDown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountDown+1).ToString();
            if(selectCountDown<=0){
                selectCountDown=0;
                quiz.GameOver();
            }
        }
    }
}