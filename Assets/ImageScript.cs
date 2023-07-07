using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScript : MonoBehaviour
{
    public GameObject[] CorrectImage;  //정답 미남이 이미지
    public GameObject[] WrongImage;  //오답 미남이 이미지
    public Quiz quiz;


    void Start(){
        WrongImage[0].SetActive(true);
    }
    void Update(){
        //level은 인자값으로 받아오기
        int level = 1;
        //i는 배열 값
        int i = 0;
        //레벨 별로 나오도록 하는 이미지 상이하게 만들기
        switch(level){
            case 1: 
                i=0; 
                break;
            case 2: 
                i=1;
                break;
             case 3: 
                i=2;
                break;
            case 4: 
                i=3; 
                break;
            case 5: 
                i=4; 
                break;
        }
        //정답, 오답에 따라 이미지 다르게 보이기
        if(quiz.check){
            CorrectImage[i].SetActive(true);
            WrongImage[i].SetActive(false);
        } 
        else{
            WrongImage[i].SetActive(true);
            CorrectImage[i].SetActive(false);
        }
    }
}
