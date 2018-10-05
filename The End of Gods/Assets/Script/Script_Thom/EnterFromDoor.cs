using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFromDoor : MonoBehaviour {
    [SerializeField] string tagDoor;

	void Start () {
        if (EnterDoor.getTeleportHasBeenUsed())
        {
            
            if(gameObject.tag == EnterDoor.getTag())
            {
                print("eg;rajgoi");
                GameObject player = GameObject.FindWithTag("Player");    
            player.transform.position = new Vector3(GameObject.FindGameObjectWithTag(tagDoor).transform.position.x, GameObject.FindGameObjectWithTag(tagDoor).transform.position.y ,0);
            EnterDoor.setTeleportHasBeenUsed();
            }
            
        }
	}
	
	void Update () {
		
	}
}
