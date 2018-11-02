using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPlayerSpwan : MonoBehaviour {

    [SerializeField] GameObject knight_base;
	void Start () {

      if(Player_Info.characterName == "knight_base")
        {
            Player_Info.Character = knight_base;
        }

    }
	

}
