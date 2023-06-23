using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject TutorialPanel; //게임 방법 패널
    public TimerSet timerSet;

    public void StartBtn()
    {
        TutorialPanel.SetActive(false);
    }

}
