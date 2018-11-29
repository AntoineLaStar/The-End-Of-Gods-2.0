using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSound : MonoBehaviour {
    [SerializeField] AudioClip adventureMusic;

    void Start () {
   
        Invoke("reduceHubMusicTo0",2f);       
    }

    private void reduceHubMusicTo0()
    {
        AudioSource theMusic = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        while (theMusic.volume > 0)
        {   
            theMusic.volume -= 0.1f;
        }
        theMusic.clip = adventureMusic;
        while (theMusic.volume < 1)
        {
            theMusic.volume += 0.1f;
        }
        theMusic.Play();
    }
}
