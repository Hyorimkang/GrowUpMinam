using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goExerciseScene : MonoBehaviour
{
    public void ExerciseButton(){  //운동하기 화면으로 전환
        SceneManager.LoadScene("ExerciseScene");
        Debug.Log("운동하기 버튼 클릭!");
    }
    
}
