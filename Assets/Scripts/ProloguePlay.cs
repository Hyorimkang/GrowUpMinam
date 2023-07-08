using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProloguePlay : MonoBehaviour
{
    public Text TalkText;  //말풍선 텍스트
    int clickCount = 0;  //클릭 횟수
    public GameObject CurrentExplainPanel;  //현재 상황 설명해주는 패널
    public GameObject MotherAndMinamPanel;  //미남이와 엄마의 대화 패널
    public GameObject TalkPanel;  //말풍선 패널
    public GameObject GameRulePanel;  //게임방법 패널
    public GameObject Mother;  //미남이 엄마
    public GameObject CryingMinam;  //울고 있는 미남이
    void Update()
    {
        if(Input.GetMouseButtonUp(0) || Input.touchCount>0){  //터치하면
            clickCount++;
        }
        if(clickCount == 0){
            TalkText.text = "내 이름은 미남";
        }else if(clickCount == 1){
            TalkText.text = "백수다.";
        }else if(clickCount == 2){
            TalkText.text = "아... 나도 슬슬 취업을 해야 하는데...";
        }else if(clickCount == 3){
            TalkText.text = "불효자 인생이 벌써 3년이 넘어간다.";
        }else if(clickCount == 4){
            TalkText.text = "이런 삶이 영원할 거라고 생각했다.";
        }else if(clickCount == 5){
            TalkText.text = "엄마가 돌아가시기 전까지는.";
        }else if(clickCount == 6){
            CurrentExplainPanel.SetActive(false);  //현재 상황 설명 패널 안 보이게 함
            MotherAndMinamPanel.SetActive(true);  //미남이와 엄마의 대화 패널 보이게 함
            TalkText.text = "미남아... 지금처럼 사는 것도 좋지만";
        }else if(clickCount == 7){
            TalkText.text = "엄마는 미남이가 어깨펴고 당당하게 살았으면 좋겠어...";
        }else if(clickCount == 8){
            TalkText.text = "살도 빼고... 취직도 하고... 여자도 만나고...";
        }else if(clickCount == 9){
            TalkText.text = "그렇게 사람답게 살았으면 좋겠어...";
        }else if(clickCount == 10){
            TalkText.text = "이게 엄마... 마지막 소원이야...";
        }else if(clickCount == 11){
            Mother.SetActive(false);  //엄마 안 보이게 함
            CryingMinam.SetActive(true);  //울고 있는 미남이 보이게 함
            TalkText.text = "엄마!!!!!";
        }else if(clickCount == 12){
            TalkText.text = "지금까지 엄마에게 너무 못난 꼴만 보여줬었어...";
        }else if(clickCount == 13){
            TalkText.text = "난 아직 아무것도 해준 게 없는데...";
        }else if(clickCount == 14){
            TalkText.text = "엄마를 위해서라도 이젠 정말 달라질거야.";
        }else if(clickCount == 15){
            TalkText.text = "다이어트도 하고 열심히 공부도 해서 취직할거야!";
        }else if(clickCount == 16){
            TalkText.text = "엄마... 천국에서 지켜보고 있어. 꼭 달라질테니까";
        }else if(clickCount == 17){
            MotherAndMinamPanel.SetActive(false);  //미남이와 엄마 대화 패널 안 보이게 함
            TalkPanel.SetActive(false);  //말풍선 패널 안 보이게 함
            GameRulePanel.SetActive(true);  //게임방법 패널 보이게 함
        }

    }
		
}

