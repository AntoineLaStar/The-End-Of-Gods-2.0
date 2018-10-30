using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPlayerSpwan : MonoBehaviour {

	// Use this for initialization
	void Start () {

      GameObject OldPlayer =  GameObject.FindGameObjectWithTag("Player");
       GameObject goodPlayer = Instantiate(Player_Info.CharacterName);
        goodPlayer.transform.position = OldPlayer.transform.position;

        Destroy(OldPlayer);

    }
	

}
