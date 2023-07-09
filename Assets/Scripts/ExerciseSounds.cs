using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseSounds : MonoBehaviour
{
    public AudioClip FatTouchSoundClip;  //지방 터치 효과음
    public AudioClip BGMClip;  //운동하기 화면 브금
    public AudioSource audioSource;  //오디오소스
    public static ExerciseSounds instance;
    void Awake()
    {
        if(ExerciseSounds.instance == null)
        {
            ExerciseSounds.instance = this;
        }
    }

    public void FatTouchSound(){  //지방 터치 효과음
        audioSource.PlayOneShot(FatTouchSoundClip);
    }

    public void BGM(){  //운동하기 화면 브금
        audioSource.clip = BGMClip;
        audioSource.Play();
    }
}
