using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudySounds : MonoBehaviour
{
    public AudioClip StudyBGMClip;  //공부하기 화면 브금
    public AudioClip CorrectClip;  //정답 효과음
    public AudioClip WrongClip;  //오답 효과음
    public AudioSource audioSource;  //오디오소스
    public static StudySounds instance;

    void Awake()
    {
        if(StudySounds.instance == null)
        {
            StudySounds.instance = this;
        }
    }
    public void StudyBGM(){  //공부하기 화면 브금
        audioSource.clip = StudyBGMClip;
    }

    public void Correct(){  //정답 효과음
        audioSource.PlayOneShot(CorrectClip);
    }
    public void Wrong(){  //오답 효과음
        audioSource.PlayOneShot(WrongClip);
    }
}
