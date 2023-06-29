using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public List<QuizandAnswer> QnA;  //질문 리스트
    public GameObject[] options;  //정답을 옵션 배열
    public int currentQuestion;  //질문 할 개수
    public Text QuestionText;  //질문 텍스트
    public Text ScoreText;  //점수 
    public GameObject QuizPanel;  //질문을 띄울 패널
    public GameObject GoPanel;  //게임오버 패널
    public StartBtn StartBtn;  //시작 버튼
    public TimerSet timerSet; //타이머
    
    private int totalQuiz = 0;  //총 질문 개수
    private int score;  //정답 개수
    
    //시작
    private void Start(){
        totalQuiz = QnA.Count;
        GoPanel.SetActive(false);
        makeQuestion();
        
        StudySounds.instance.StudyBGM(); //BGM 재생
    }

    //게임 시작 버튼 눌렀을 때
    public void GameStart(){
        timerSet.timer();
        StartBtn.StartButton();
    }

    //게임 종료
    public void GameOver(){
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = "맞춘 개수 : "+score;
    }

    //정답
    public void correct(){
        score+=1; 
        QnA.RemoveAt(currentQuestion);
        makeQuestion();
        StudySounds.instance.Correct(); //정답 시 효과음
    }
    
    //오답
    public void wrong(){
        if (currentQuestion >= 0 && currentQuestion < QnA.Count)
        {
            QnA.RemoveAt(currentQuestion);
            StudySounds.instance.Wrong(); //오답 시 효과음
        }
        makeQuestion();
    }

    //질문
    void makeQuestion(){
        if(QnA.Count > 0){
            currentQuestion = Random.Range(0,QnA.Count);
            QuestionText.text = QnA[currentQuestion].Quiz; 
            SetAnswers();
        }
        else{
            Debug.Log("다 풀었습니다.");
            GameOver();
        }
    }

    //정답 구분
    void SetAnswers(){
        for(int i = 0; i<options.Length; i++){
            options[i].GetComponent<Answer>().isCorrect=false;
            options[i].transform.GetChild(0).GetComponent<Text>().text=QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer==i+1){
                options[i].GetComponent<Answer>().isCorrect=true;
            }
        }
    }
} 
