using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

    public Text KnowledgeText;  //지식 수준 텍스트
    public Text WeightText;  //몸무게 텍스트
    public Text LevelText;  //레벨 텍스트
    public static int Knowledge;  //지식 수준
    public static int Weight = 120;  //몸무게(일단은 120kg으로 설정)

    void Update()
    {
        WeightText.text = "몸무게: " + Weight + "kg";  //몸무게 텍스트 설정
        KnowledgeText.text = "지식: " + Knowledge;  //지식 수준 텍스트 설정
        LevelText.text = "레벨: "+ (PlayerPrefs.GetInt("레벨")+1) + "단계";  //레벨 텍스트 설정
    }
}
