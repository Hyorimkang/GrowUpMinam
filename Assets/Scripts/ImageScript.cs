using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScript : MonoBehaviour
{
    public GameObject[] CorrectImage;  //정답 미남이 이미지
    public GameObject[] WrongImage;  //오답 미남이 이미지
    public Quiz quiz;
    private int level; //현재 레벨
    private int i;
    

    void Start(){
        //level을 받아오기
        PlayerPrefs.SetInt("레벨", level); 
        WrongImage[level].SetActive(true);
    }
    void Update(){
        
        //처음에는 모든 미남이 false만들기 
        for(i = 0; i<5; i++){
            CorrectImage[i].SetActive(false);
            WrongImage[i].SetActive(false);
        }

        //정답, 오답에 따라 이미지 다르게 보이기
        if(quiz.check){
            CorrectImage[level].SetActive(true);
            WrongImage[level].SetActive(false);
        } 
        else{
            WrongImage[level].SetActive(true);
            CorrectImage[level].SetActive(false);
        }
    }
}
