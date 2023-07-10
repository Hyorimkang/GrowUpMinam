using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Button ExerciseButton;
    public Button DietButton;
    public Button StudyButton;

    // private void Start() {
    //     ExerciseButton.interactable = true;
    //     StudyButton.interactable = true;
    // }
    private void Update() 
    {
        if(PlayerPrefs.GetString("운동하기버튼").Equals("활성화")){  //아직 운동하기 게임을 플레이하지 않았다면 버튼 활성화
            ExerciseButton.interactable = true;
        }
        else if(PlayerPrefs.GetString("운동하기버튼").Equals("비활성화")){  //운동하기 게임을 플레이 했다면 버튼 비활성화
            ExerciseButton.interactable = false;
        }
        if(PlayerPrefs.GetString("식단하기버튼").Equals("활성화")){  //아직 식단하기 게임을 플레이하지 않았다면 버튼 활성화
            DietButton.interactable = true;
        }
        else if(PlayerPrefs.GetString("식단하기버튼").Equals("비활성화")){  //식단하기 게임을 플레이 했다면 버튼 비활성화
            DietButton.interactable = false;
        }
        if(PlayerPrefs.GetString("공부하기버튼").Equals("활성화")){  //아직 공부하기 게임을 플레이하지 않았다면 버튼 활성화
            StudyButton.interactable = true;
        }
        else if(PlayerPrefs.GetString("공부하기버튼").Equals("비활성화")){  //공부하기 게임을 플레이 했다면 버튼 비활성화
            StudyButton.interactable = false;
        }
    }
}
