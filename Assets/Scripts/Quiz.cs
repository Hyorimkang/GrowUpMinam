using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public List<QuizandAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionText;
    public Text ScoreText;
    public GameObject QuizPanel;
    public GameObject GoPanel;
    
    int totalQuiz = 0;
    public int score;
//시작
    private void Start(){
        totalQuiz = QnA.Count;
        GoPanel.SetActive(false);
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

//정답
    public void correct(){
        score+=1; 
        QnA.RemoveAt(currentQuestion);
        makeQuestion();
    }

//오답
    public void wrong(){
        QnA.RemoveAt(currentQuestion);
        makeQuestion();
    }

//게임 종료
    void GameOver(){
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = "맞춘 개수 : "+score;
    }
} 

