using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoStartScene : MonoBehaviour
{
    public void BackButton(){  //처음 화면으로 전환
        SceneManager.LoadScene("Start_Scene");
    }
}
