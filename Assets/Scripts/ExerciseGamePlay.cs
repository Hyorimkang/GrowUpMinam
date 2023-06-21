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


    //게임시작 버튼을 눌렀을때
    public void GameStart(){
        PlayStartPanel.SetActive(false);  //시작 패널 안보이게함
        SpawnObject();  //초기 지방 오브젝트 생성
    }

    void Update()
    {
        
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))  //클릭하거나 터치했을때
        {
            touch = Input.mousePosition;  //터치하거나 클릭한걸로 조건에 따라 바꿔줘야함
            // touch = Input.GetTouch(0).position;
            
            Debug.Log("그냥클릭");
            // 터치된 위치를 기반으로 Ray를 생성하여 충돌 체크
            Vector2 tp = Camera.main.ScreenToWorldPoint(touch);
            RaycastHit2D hit = Physics2D.Raycast(tp, Vector2.zero);

            if (hit.collider != null && objectsList.Contains(hit.collider.gameObject))
            {
                Debug.Log("지방 터치!");
                // 오브젝트를 터치한 경우
                IncreaseScore();  //점수 증가 
                RemoveObject(hit.collider.gameObject);  //지방 오브젝트 제거
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
        scoreText.text = "제거한 지방 수: " + score.ToString();
    }

    private void RemoveObject(GameObject obj)  //지방 오브젝트 제거
    {
        Debug.Log("지방제거");
        objectsList.Remove(obj);  //리스트에서 제거
        Destroy(obj);  //아예 제거
    }

    private void SpawnObject()
    {
        
        // 화면 크기에 맞게 랜덤 위치 생성
        float x = Random.Range(Screen.width * 0.1f, Screen.width * 0.9f);
        float y = Random.Range(Screen.height * 0.1f, Screen.height * 0.9f);
        Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(x, y, Camera.main.nearClipPlane));

        // 오브젝트 생성
        GameObject newFatObject = Instantiate(fat, randomPosition, Quaternion.identity);
        objectsList.Add(newFatObject);
    }
}
