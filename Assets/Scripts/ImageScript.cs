using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScript : MonoBehaviour
{
    public GameObject[] CorrectImage;  //정답 미남이 이미지
    public GameObject[] WrongImage;  //오답 미남이 이미지
    public Quiz quiz;
    private int level = 3; //현재 레벨
    private int i;
    

    void Start(){
        //level을 받아오기
        //PlayerPrefs.SetInt("레벨", level); 
        WrongImage[level-1].SetActive(true);
        //ChangeImage(level);
    }
    void Update(){
        
        //처음에는 모든 미남이 false만들기 
        for(i = 0; i<3; i++){
            CorrectImage[i].SetActive(false);
            WrongImage[i].SetActive(false);
        }

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
