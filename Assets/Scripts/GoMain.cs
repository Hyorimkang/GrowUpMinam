using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMain : MonoBehaviour
{
    public void GoMainButton(){  //운동하기 화면으로 전환
        SceneManager.LoadScene("MainScene");
        Debug.Log("메인가기 버튼 클릭!");
    }
}
