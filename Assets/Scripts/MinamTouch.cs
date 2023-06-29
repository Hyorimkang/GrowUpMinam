using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinamTouch : MonoBehaviour
{
    Vector2 touchPosition;
    string[] MinamSay = {"엄마...","내가 성공할 수 있을까?", "쩝쩝짭짭짭","여동생을 날 어떻게\n생각할까?","아자!아자!"};  //미남이 말풍선 텍스트
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
        BubbleText.text = MinamSay[Random.Range(0, MinamSay.Length)];  //랜덤으로 대사가 나옴
        Bubble.SetActive(true);
        timer = 0f;
    }

    void HideSpeechBubble(){  //말풍선 안보이게
        Bubble.SetActive(false);
    }
}