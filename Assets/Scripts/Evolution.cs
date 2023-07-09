using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evolution : MonoBehaviour
{
    public GameObject BeforePanel;  // 진화전
    public GameObject EvolutionPanel;  //진화중
    public GameObject AfterPanel; //진화후
    private float timer = 3f; //타이머
    private float selectCountDown; //카운트 다운

    public void Start()
    {
        selectCountDown = timer;
        EvolutionPanel.SetActive(false);
        AfterPanel.SetActive(false);
        //Before();
    }

    // public void Before(){
    //     Debug.Log("update 실행");
    //     selectCountDown -= Time.deltaTime;
    //     Debug.Log(timer);
    //     //3초가 지나면 BeforePanel 안보이게 하기
    //     if(selectCountDown==0){
    //         BeforePanel.SetActive(false);
    //         Evolutioning();
    //     }
    // }
    
    // public void Evolutioning(){
    //     EvolutionPanel.SetActive(true);
    //     Debug.Log("Evolutioning 실행");
    //     selectCountDown = timer;
    //     selectCountDown -= Time.deltaTime;

    //     EvolutionSound.instance.Evolutioning();  //진화 효과음 내기

    //     //3초간 EvolutionPanel 보여주기
    //     if(selectCountDown==0){
    //         EvolutionPanel.SetActive(false);
    //         AfterPanel.SetActive(true);
    //     }
          
    // }

    void Update(){
        //if(BeforePanel == true && EvolutionPanel==false && AfterPanel==false){
            Debug.Log("update 실행");
            selectCountDown -= Time.deltaTime;

            if(selectCountDown <= 0){
                DestroyImmediate(BeforePanel, false);
            }
            //EvolutionPanel.SetActive(true);
        //}
        //else if(BeforePanel == false && EvolutionPanel==true && AfterPanel==false){
            selectCountDown = timer;
            Debug.Log("Evolutioning 실행");
            selectCountDown -= Time.deltaTime;

            if(selectCountDown <= 0){
                DestroyImmediate(EvolutionPanel, false);
            }
            //AfterPanel.SetActive(true);
        //}
        
    }
        //진화전 2초
        //흰 화면 2초동안 말풍선으로 어엇, 내 몸이 이상해! 띄우기, 효과음 재생
        //진화후 보여주기 1초후 밑에 완료버튼 띄우기 
}
