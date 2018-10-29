using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    KeyCode keyPressed = KeyCode.None;
    AudioSource sourceAudio;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }



    public void FrapperSound()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {

            if (Input.GetKey(vKey))
            {
                keyPressed = vKey;
                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Attack"))
                {
                    sourceAudio = GetComponent<AudioSource>();
                    sourceAudio.Play();
                    sourceAudio.volume = 5f;
                }

            }
        }
    }
}
   

