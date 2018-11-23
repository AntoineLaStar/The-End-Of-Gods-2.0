using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{

    [SerializeField] public Sprite backgroundSprite;

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
        print("here");
           SceneManager.LoadScene(linkScene);
        //Background();
    }
    static public void setTeleportHasBeenUsed()
    {
        DoorHasBeenUsed = !DoorHasBeenUsed;
    }
    static public string getTag()
    {
        return tag;
    }


    public void Background()
    {
        /*GameObject background = GameObject.FindGameObjectWithTag("background");
        if (background)
        {
            print("found");
            print("here123");
            background.GetComponent<SpriteRenderer>().sprite = backgroundSprite;
        }
        else
        {
            print("not found");
        }
        print(gameObject.tag);
        if (background)
        {
            
        }*/
       
    
    /*if (gameObject.tag == "OutsideDoor")
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = outside;
    }
    else if (gameObject.tag == "hellDoor")
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = hell;
    }*/
}
    
}
