using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinamTouch : MonoBehaviour
{
    Vector2 touchPosition;
    string[] minamSay = {"엄마..."};  //미남이 말풍선 텍스트
    bool isClicked = false;  // 클릭 이벤트 발생 여부를 저장하는 변수

    void Update()
    {
        //미남이를 터치했을때 랜덤으로 말풍선이 나옴
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

        if (hit.collider != null && isClicked)  //미남이 클릭했을때 터치이벤트 발생
        {
            
            Debug.Log("클릭");
            isClicked = false; //터치 이벤트가 발생했으니 다음 프레임에선 발생하지 않도록 false로 변경해줌
            //말풍선 이벤트 발생
        }
        
    }
}