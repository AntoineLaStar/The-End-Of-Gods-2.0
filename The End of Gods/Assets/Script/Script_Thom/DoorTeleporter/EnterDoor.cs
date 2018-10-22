using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    [SerializeField] string linkScene;
    static string tag;
    static bool DoorHasBeenUsed = false;
    void Start()
    {

    }

    static public bool getTeleportHasBeenUsed()
    {
        return DoorHasBeenUsed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyUp(vKey))
                {
                    KeyCode keyPressed = vKey;
                    if (keyPressed.ToString() == KeyImputManager.GetKeyBind("interact"))
                    {
                        tag = gameObject.tag;
                        enterTeleporter();
                    }
                }
            }
        }

    }

    private void enterTeleporter()
    {
        
            DoorHasBeenUsed = true;
            SceneManager.LoadScene(linkScene);
        
    }
    static public void setTeleportHasBeenUsed()
    {
        DoorHasBeenUsed = !DoorHasBeenUsed;
    }
    static public string getTag()
    {
        return tag;
    }
    
}
