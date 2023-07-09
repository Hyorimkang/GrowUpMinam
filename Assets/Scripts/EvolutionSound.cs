using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionSound : MonoBehaviour
{

    public AudioClip EvolutionClip;  //진화 효과음
    public AudioSource audioSource;  //오디오 소스
    public static EvolutionSound instance;  
 
    void Awake(){
        if(EvolutionSound.instance == null)
        {
            EvolutionSound.instance = this;
        }
    }

    public void Evolutioning(){  //진화 효과음
        audioSource.PlayOneShot(EvolutionClip);
    }
}
