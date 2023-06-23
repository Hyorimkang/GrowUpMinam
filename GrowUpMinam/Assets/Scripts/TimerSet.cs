using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSet : MonoBehaviour
{
    public Quiz quiz;
    public Text timerTxt;
    public float time = 10f; //제한 시간
    private float selectCountDown; //카운트 다운

    // Start is called before the first frame update
    void Start()
    {
        selectCountDown = time;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Floor(selectCountDown)<=0){
            quiz.wrong();
        }
        else{
            selectCountDown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountDown).ToString();
        }
    }
}
