using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

    public Text KnowledgeText;  //지식 수준 텍스트
    public Text WeightText;  //몸무게 텍스트
    public Text LevelText;  //단계 텍스트

    //db를 써야할듯...
    public static int Knowledge;  //지식 수준
    public static int Weight = 120;  //몸무게(일단은 120kg으로 설정)

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeightText.text = "몸무게: " + Weight + "kg";  //몸무게 텍스트 설정

    }
}
