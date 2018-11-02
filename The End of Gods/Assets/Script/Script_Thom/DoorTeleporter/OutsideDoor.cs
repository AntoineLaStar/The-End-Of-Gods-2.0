using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideDoor : MonoBehaviour {
    [SerializeField] string linkScene;
    static string tag;
    [SerializeField] Canvas errorMessage;
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
            if(Player_Info.CharacterName != "knight_base")
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
            else
            {
                showErrorMessage();
            }
            
        }

    }

    private void showErrorMessage()
    {
        errorMessage.enabled = !errorMessage.enabled;
        KeyImputManager.changeLockState();
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
