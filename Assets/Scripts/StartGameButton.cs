using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    public void GoPrologScene(){
        SceneManager.LoadScene("PrologueScene");
        Debug.Log("프롤로그 씬 가기 버튼 클릭!");
    }
}
