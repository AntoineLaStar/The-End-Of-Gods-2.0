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
        PlayerPlatformerController player = gameObject.GetComponent<PlayerPlatformerController>();
        player.dealDamage(Player_Info.startingHealth + 1);
    }

}
