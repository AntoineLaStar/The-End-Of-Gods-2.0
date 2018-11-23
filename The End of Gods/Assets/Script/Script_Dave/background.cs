using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class background : MonoBehaviour {

    

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
