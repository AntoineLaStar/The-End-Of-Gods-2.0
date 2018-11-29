using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {

    public void Update()
    {
   
    }

 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "trap")
        {
          
            killPlayer();
       
        }
    }

    public void killPlayer()
    {
        Animator playerAnimator = gameObject.GetComponent<Animator>();
        playerAnimator.Play("knight_1_Die");
        Player_Info.CharacterName = "knight_base";
        Invoke("TeleportPlayer", 1f);
    }
    private void TeleportPlayer()
    {
        SceneManager.LoadScene("Scenes/Hell");
    }


}
