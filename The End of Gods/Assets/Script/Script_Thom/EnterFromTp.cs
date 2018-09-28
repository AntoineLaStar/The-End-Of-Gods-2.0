using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFromTp : MonoBehaviour {

	void Start () {
        if (EnterTeleporter.getTeleportHasBeenUsed())
        {
            GameObject player = GameObject.FindWithTag("Player");    
            player.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y- 1.25f,0);
            EnterTeleporter.setTeleportHasBeenUsed();
        }
	}
	
	void Update () {
		
	}
}
