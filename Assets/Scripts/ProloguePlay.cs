using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProloguePlay : MonoBehaviour
{
    public Text TalkText;  //말풍선 텍스트
    int clickCount = 0;  //클릭 횟수
    public GameObject CurrentExplainPanel;  //현재 상황 설명해주는 패널
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
        }

    }
		
}

