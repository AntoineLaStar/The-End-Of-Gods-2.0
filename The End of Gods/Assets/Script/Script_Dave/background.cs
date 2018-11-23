using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class background : MonoBehaviour {

    [SerializeField] public Sprite CastleWall;
    [SerializeField] public Sprite outside;
    [SerializeField] public Sprite hell;

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
                            if(gameObject.tag == "OutsideDoor")
                        {
                            gameObject.GetComponent<SpriteRenderer>().sprite = outside;
                        }
                            else if (gameObject.tag == "hellDoor")
                        {
                            gameObject.GetComponent<SpriteRenderer>().sprite = hell;
                        }

                            
                        }
                    }
                }
            }

        }




        //var currentScene = SceneManager.GetActiveScene();
        //var currentSceneName = currentScene.name;
        //if (currentSceneName == "room" )
        
           
        //    gameObject.GetComponent<SpriteRenderer>().sprite = CastleWall;
        
        //    gameObject.GetComponent<SpriteRenderer>().sprite = outside;
        
        
    



}
