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
    public static int level;  //레벨

    void Update()
    {
        WeightText.text = "몸무게: " + Weight + "kg";  //몸무게 텍스트 설정
        KnowledgeText.text = "지식: " + Knowledge;  //지식 수준 텍스트 설정
        
    }
    void LevelUP(){  //레벨업
        if(Weight<=100 && Knowledge == 100){  //100kg, 지식이 100이면 2단계로 레벨업
            //일단은 그냥 해둔거임 알아서 수정~
        }
    }
}
