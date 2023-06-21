using UnityEngine;
using UnityEngine.SceneManagement;

public class GoStudyScene : MonoBehaviour
{
    public void StudyButton(){  //운동하기 화면으로 전환
        SceneManager.LoadScene("StudyMode");
        Debug.Log("공부하기 버튼 클릭!");
    }
}
