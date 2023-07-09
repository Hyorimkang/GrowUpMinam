using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinamTouch : MonoBehaviour
{
    Vector2 touchPosition;
    string[] FirstMinamSay = {"엄마...","내가 성공할 수 있을까?", "엄마를 다시 만날 수 \n있다면...","아자!아자!"};  //1단계 미남이 말풍선 텍스트
    string[] SecondMinamSay = {"엄마...","노력하는 건 역시 힘들어", "힘내야지...","나도 사람답게 살 수 \n있을까?"};  //2단계 미남이 말풍선 텍스트
    string[] ThirdMinamSay = {"엄마...","확실히 자신감이 생겼어.", "공부하는 게 즐거워","헬스장을 다닐까?"};  //3단계 미남이 말풍선 텍스트
    string[] FourthMinamSay = {"엄마...","좀 잘생겨진 것 \n같기도 하고...", "운동하는 게 즐거워","진로를 정해야 해."};  //4단계 미남이 말풍선 텍스트
    string[] FifthMinamSay = {"엄마...","예전의 내가 아니야.", "엄마에게 이 모습을 \n보여주고 싶어.","매일매일이 즐거워."};  //5단계 미남이 말풍선 텍스트
    public Text BubbleText;  //말풍선 대사 텍스트
    public GameObject Bubble;  //말풍선 오브젝트
    bool isClicked = false;  // 클릭 이벤트 발생 여부를 저장하는 변수
    private float timer = 0f;  // 타이머 변수
    private float hideDelay = 4f;  //말풍선 숨기기 지연시간

    private void Start() {
        Bubble.SetActive(false);  //말풍선 안보이게 함
        RectTransform BubbleRectTransform = Bubble.GetComponent<RectTransform>();
        BubbleRectTransform.position = new Vector3(1050, BubbleRectTransform.position.y, BubbleRectTransform.position.z);  //말풍선 위치
        BubbleRectTransform.pivot = new Vector2(0f, 0.5f);//말풍선 위치 고정
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){  //마우스 클릭
	        touchPosition = Input.mousePosition;
            isClicked = true;
        }
        if(Input.touchCount > 0){  //터치
            touchPosition = Input.GetTouch(0).position;
            isClicked = true;
        }
        Vector2 tp = Camera.main.ScreenToWorldPoint(touchPosition);
        RaycastHit2D hit = Physics2D.Raycast(tp, Vector2.zero);

        if (hit.collider != null && isClicked)  //미남이 클릭했을때 말풍선 생김
        {
            isClicked = false;
            SpeechBubble();  //말풍선 나옴
        }
        timer += Time.deltaTime;

        if (timer >= hideDelay)// 4초 지나면 말풍선 숨기기
        {
            HideSpeechBubble();  //말풍선 숨기기
            timer = 0f;  //타이머 초기화
        }
        
    }
    void SpeechBubble(){  //말풍선 보이게
        switch(PlayerPrefs.GetInt("레벨")){  //랜덤으로 레벨별 미남이의 대사가 나옴
            case 0: BubbleText.text = FirstMinamSay[Random.Range(0, FirstMinamSay.Length)]; break;
            case 1: BubbleText.text = SecondMinamSay[Random.Range(0, SecondMinamSay.Length)]; break;
            case 2: BubbleText.text = ThirdMinamSay[Random.Range(0, ThirdMinamSay.Length)]; break;
            case 3: BubbleText.text = FourthMinamSay[Random.Range(0, FourthMinamSay.Length)]; break;
            case 4: BubbleText.text = FifthMinamSay[Random.Range(0, FifthMinamSay.Length)]; break;
        }
        Bubble.SetActive(true);
        timer = 0f;
    }

    void HideSpeechBubble(){  //말풍선 안보이게
        Bubble.SetActive(false);
    }
}