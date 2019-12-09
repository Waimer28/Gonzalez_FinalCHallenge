using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip musicClipOne;

    public AudioSource musicSource;

   
    void Start()
    {
        musicSource.clip = musicClipOne;
        musicSource.Play();
        musicSource.loop = true;
    }


    void Update()
    {
       
    }
   
}
