using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDing : MonoBehaviour
{
    public AudioClip musicClipThree;

    public AudioSource musicSource;
    void Start()
    {

    }

    
    void Update()
    {
 
     
       
    }
    void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.collider.tag == "Player")
        {
            musicSource.clip = musicClipThree;
            musicSource.Play();
            musicSource.loop = false;
        }
    }
}
