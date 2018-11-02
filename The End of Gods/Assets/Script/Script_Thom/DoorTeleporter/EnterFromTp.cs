using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFromTp : MonoBehaviour {
    [SerializeField] string tagTp;

	void Start () {
        if (EnterTeleporter.getTeleportHasBeenUsed())
        {
            if(gameObject.tag == EnterTeleporter.getTag())
            {
            GameObject player = GameObject.FindWithTag("Player");    
            player.transform.position = new Vector3(GameObject.FindGameObjectWithTag(tagTp).transform.position.x, GameObject.FindGameObjectWithTag(tagTp).transform.position.y - 1.25f,0);
             changePlayerType();
            EnterTeleporter.setTeleportHasBeenUsed();
            }
            
        }
	}

    private void changePlayerType()
    {

        GameObject OldPlayer = GameObject.FindGameObjectWithTag("Player");
        GameObject goodPlayer = Instantiate(Player_Info.Character);
        goodPlayer.transform.position = OldPlayer.transform.position;
        HitTracker.HaveHit = false;

        Destroy(OldPlayer);
    }

 
}
