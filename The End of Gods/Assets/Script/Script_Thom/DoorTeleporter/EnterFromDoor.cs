using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFromDoor : MonoBehaviour {
    [SerializeField] string tagDoor;

    [SerializeField] public Sprite backgroundSprite;


    void Start () {
        if (EnterDoor.getTeleportHasBeenUsed())
        {
    
            if (gameObject.tag == EnterDoor.getTag())
            {
                GameObject player = GameObject.FindWithTag("Player");
                
                player.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-1.30f ,0);
                changePlayerType();
                EnterDoor.setTeleportHasBeenUsed();
     
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

    public void Background()
    {
        /*GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("background");
        foreach(GameObject background in backgrounds)
        {
            background.GetComponent<SpriteRenderer>().sprite = backgroundSprite;
            print("done");
        }*/
        /*if (background)
        {
            print("found");
            print("here123");
            
            print("done");
        }
        else
        {
            print("not found");
        }*/
    }
}
