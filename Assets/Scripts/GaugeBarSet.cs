using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GaugeBarSet : MonoBehaviour
{
    public Image GaugeBarImage;  //게이지 이미지
    static float Gauge;  //게이지 양 저장 변수
    private void Update() {
        //게임 종료가 되면 값을 받아와 게이지바를 채움
        if(PlayerPrefs.GetString("게임실행여부").Equals("게임종료")){
            int weightLoss = PlayerPrefs.GetInt("WeightLoss");
            GaugeFill((float)weightLoss);
            PlayerPrefs.SetString("게임실행여부","하고있음");
        }
    }
    public void GaugeFill(float amount)  //게이지바 채우기
    {
        Gauge += amount / 50f;
        GaugeBarImage.fillAmount = Gauge; 
        Debug.Log("게이지 채움");
    }
}
