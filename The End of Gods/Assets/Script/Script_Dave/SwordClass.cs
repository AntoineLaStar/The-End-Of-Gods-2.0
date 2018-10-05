using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordClass : MonoBehaviour {

   
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
    }

      




    public void podiumSwordChangeSprite()
    {
        Sprite podium;
        podium = Resources.Load<Sprite>("podium");

        GameObject Sword = GameObject.FindGameObjectWithTag("Podium_Sword");
         

        Sword.GetComponent<SpriteRenderer>().sprite = podium;

    }





}
