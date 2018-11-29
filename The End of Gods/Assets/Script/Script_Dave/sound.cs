using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public static KeyCode keyPressed = KeyCode.None;
    static AudioSource sourceAudio;
    public static AudioClip Swoosh;
    // Use this for initialization
    void Start()
    {
        Swoosh = Resources.Load<AudioClip>("Swoosh");
        sourceAudio = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        //sourceAudio.PlayOneShot(Swoosh);
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                keyPressed = vKey;
                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Attack"))
                {
                    sourceAudio.Play();
                }
            }
        }
    }

}
   

