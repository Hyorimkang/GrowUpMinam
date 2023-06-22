using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    Vector2 touch;
    public GameObject fat;  //지방 오브젝트
    public Text scoreText;  //점수를 표시할 텍스트 UI
    public GameObject PlayStartPanel;  //게임 시작 전 패널
    private List<GameObject> objectsList = new List<GameObject>();  // 생성된 오브젝트를 저장할 리스트
    private int score = 0;  //터치한 지방 수
    private float spawnDelay = 1f;  // 오브젝트 생성 딜레이
    private float spawnTimer = 0f;  // 오브젝트 생성 타이머
    private int maxObjectCount = 5;  // 화면에 표시될 최대 오브젝트 수

    //게임시작 버튼을 눌렀을 때
    public void GameStart()
    {
        PlayStartPanel.SetActive(false);  //시작 패널 안보이게 함
        SpawnInitialObjects();
    }

    void Update()
    {
        //터치
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && objectsList.Contains(hitCollider.gameObject))// 오브젝트를 터치한 경우
            {
                IncreaseScore();  // 점수 증가
                RemoveObject(hitCollider.gameObject);  // 지방 오브젝트 제거
                SpawnObject();  // 새로운 오브젝트 생성
            }
        }
        // 타이머 업데이트
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnDelay)
        {
            // 오브젝트 생성 타이머가 딜레이 이상일 때
            spawnTimer = 0f;  // 타이머 초기화
            SpawnObject();  // 오브젝트 생성
        }
    }

    private void IncreaseScore()  //지방 제거하면 점수 증가
    {
        score++;
        scoreText.text = "제거한 지방: " + score.ToString();
    }

    private void RemoveObject(GameObject obj)  //지방 오브젝트 제거
    {
        Debug.Log("지방 제거");
        objectsList.Remove(obj);  //리스트에서 제거
        Destroy(obj);  //아예 제거
    }

    private void SpawnInitialObjects()
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
    private Vector3 GetRandomPositionInScreen()
    {
        // 캔버스의 사이즈를 기준으로 랜덤 위치 생성
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
