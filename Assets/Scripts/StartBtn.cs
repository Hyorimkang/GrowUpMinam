using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{  
    public GameObject TutorialPanel; //게임 방법 패널

    public void StartButton()
    {
        TutorialPanel.SetActive(false);
    }
}
