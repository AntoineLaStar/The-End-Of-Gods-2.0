using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AxeClass : MonoBehaviour {

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void podiumAxeChangeSprite()
    {
        Sprite podium;
        podium = Resources.Load<Sprite>("podium");

        GameObject Axe = GameObject.FindGameObjectWithTag("Podium_Axe"); 
        

        Axe.GetComponent<SpriteRenderer>().sprite = podium;

    }




}

