using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "trap")
        {
          
            killPlayer();
       
        }
    }

    private void killPlayer()
    {
        Animator playerAnimator = gameObject.GetComponent<Animator>();
        playerAnimator.Play("knight_1_Die");
        Player_Info.CharacterName = "knight_base";
        Invoke("TeleportPlayer", 1f);
    }
    private void TeleportPlayer()
    {
        Animator playerAnimator = gameObject.GetComponent<Animator>();
        SceneManager.LoadScene("Scenes/Hell");
    }


}
