using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public Quiz quiz;
    //정답 구분
    public void answer(){
        if(isCorrect){
            Debug.Log("맞았습니다.");
            quiz.correct();
        }
        else{
            Debug.Log("틀렸습니다.");
        }
    }
}
