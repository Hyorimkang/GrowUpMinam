using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseGamePlay : MonoBehaviour
{
    Vector2 touch;
    public GameObject fat;  //지방 오브젝트
    public Text scoreText;  //점수 텍스트
    public GameObject PlayStartPanel;  //게임 시작 전 패널
    public GameObject GameOverPanel;  //게임 종료 패널
    private List<GameObject> objectsList = new List<GameObject>();  // 생성된 오브젝트를 저장할 리스트
    private int RemoveFatCount = 0;  //제거한 지방 수
    private int maxObjectCount = 5;  // 화면에 표시될 최대 지방 오브젝트 수
    private float Timer = 31;  //30초 제한시간
    public Text TimerText;  //제한시간 텍스트
    public Text WeightLossText;  //감량 텍스트
    public Text FatCountText;  //제거한 지방 총 개수 텍스트
    bool PlayCheck = false;  //게임시작 했는지 안했는지

    private void Start() {
        GameOverPanel.SetActive(false);  //게임 종료 패널 안보이게 함
        Sounds.instance.BGM();  //브금 재생
    }

    public void GameStart()  //게임시작 버튼을 눌렀을 때
    {
        PlayStartPanel.SetActive(false);  //시작 패널 안보이게 함
        SpawnInitialObjects();  //지방 오브젝트 5개 생성
        PlayCheck = true;
    }

    void Update()
    {
        if(PlayCheck)  //게임이 시작하면
        {
            //30초 제한시간 타이머
            if((int)Timer == 0){  //제한시간 끝나면
                TimerText.text = "제한시간:종료";
                GameOverPanel.SetActive(true);  //게임 종료 패널 보이게 함
                FatCountText.text = "지방 " + RemoveFatCount + "개 제거";  //제거 개수 텍스트설정
                WeightLossText.text =  "총 " + WeightLoss() + "kg 감량 성공!";  //감량 kg 텍스트설정
                Stats.Weight -= WeightLoss();  //몸무게 감량
                PlayerPrefs.SetInt("WeightLoss", WeightLoss());  //감량한 몸무게 저장
                PlayerPrefs.SetString("게임실행여부","게임종료");  //게임종료했는지 저장
                PlayCheck = false;  //종료
            }else{
                Timer -= Time.deltaTime;
                TimerText.text = "제한시간: " + (int)Timer + "초";
            }

            if (Input.GetMouseButtonUp(0))//터치
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

                if (hitCollider != null && objectsList.Contains(hitCollider.gameObject))// 오브젝트를 터치한 경우
                {
                    Sounds.instance.FatTouchSound();  //지방 터치 효과음
                    IncreaseScore();  // 점수 증가
                    RemoveObject(hitCollider.gameObject);  // 지방 오브젝트 제거
                    SpawnObject();  // 새로운 오브젝트 생성
                }
            }
        }
        
    }
    private int WeightLoss(){  //감량한 몸무게 계산
        int loss = 0;  //감량한 몸무게
        if(RemoveFatCount>=70)  //70개 이상이면 5kg 감량
            loss = 5;
        else if(RemoveFatCount>=50)  //50개 이상이면 3kg 감량
            loss = 3;
        else if(RemoveFatCount>=20)  //20개 이상이면 2kg 감량
            loss = 2;
        else if(RemoveFatCount>=10)  //10개 이상이면 1kg 감량
            loss = 1;
        else  //10개 미만이면 0kg 감량
            loss = 0;
        return loss;
    }
    private void IncreaseScore()  //지방 제거하면 점수 증가
    {
        RemoveFatCount++;
        scoreText.text = "제거한 지방: " + RemoveFatCount;
    }

    private void RemoveObject(GameObject obj)  //지방 오브젝트 제거
    {
        objectsList.Remove(obj);  //리스트에서 제거
        Destroy(obj);  //아예 제거
    }
    private void SpawnInitialObjects()  //5개까지만 지방 오브젝트 생성
    {
        for (int i = 0; i < maxObjectCount; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()  //지방 오브젝트 랜덤 생성
    {
        if (objectsList.Count >= maxObjectCount)
            return;

        // 화면 내에서 랜덤 위치 생성
        Vector3 randomPosition = GetRandomPositionInScreen();

        // 충돌 체크
        Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPosition, 1f); // 반경 1f로 충돌 체크
        bool isColliding = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Fat"))
            {
                isColliding = true;
                break;
            }
        }

        if (!isColliding)
        {
            // 오브젝트 생성
            GameObject newFatObject = Instantiate(fat, randomPosition, Quaternion.identity);
            newFatObject.transform.position = new Vector3(newFatObject.transform.position.x, newFatObject.transform.position.y, 0f); // 생성된 객체의 Z축 위치를 0으로 설정
            objectsList.Add(newFatObject);
        }
    }
    private Vector3 GetRandomPositionInScreen()// 캔버스의 사이즈를 기준으로 랜덤 위치 생성
    {
        //화면 밖으로 지방 오브젝트가 삐져나가지 않도록 랜덤 위치 범위를 스크린 크기보다 적게 설정
        float x = Random.Range(Screen.width * 0.1f, Screen.width * 0.9f);
        float y = Random.Range(Screen.height * 0.1f, Screen.height * 0.9f);

        // 화면 좌표를 월드 좌표로 변환
        Vector3 screenPos = new Vector3(x, y, Camera.main.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0f;

        return worldPos;
    }
}
