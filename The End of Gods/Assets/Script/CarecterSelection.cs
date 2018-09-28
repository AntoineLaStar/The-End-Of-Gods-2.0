using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarecterSelection : MonoBehaviour {
    public GameObject knight_1;
    public GameObject knight_2;
    public GameObject knight_3;
    // Use this for initialization
    void Start () {
        
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Podium_Spear")
        {
            Instantiate(knight_1);
            print("miam");
        }
        else if(collision.gameObject.tag == "Podium_Sword")
        {
            
            Instantiate(knight_2);
        }
        else if(collision.gameObject.tag == "Podium_Axe")
        {
            Instantiate(knight_3);
        }
    }



    
}
