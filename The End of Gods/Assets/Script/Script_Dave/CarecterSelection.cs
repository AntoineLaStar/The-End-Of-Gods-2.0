using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarecterSelection : MonoBehaviour {
    public GameObject knight_1;
    public GameObject knight_2;
    public GameObject knight_3; 

    AxeClass Axe = new AxeClass();
    SwordClass Sword = new SwordClass();
    SpearClass Spear = new SpearClass();
    
    // Use this for initialization
    void Start () {

       // Spear = GetComponent<SpearClass>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        KeyCode keyUp = KeyCode.None;
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyUp(vKey))
            {
                keyUp = vKey;
                

                if (keyUp.ToString() == KeyImputManager.GetKeyBind("interact"))
                {

                   
                        if (collision.gameObject.tag == "Podium_Spear")
                        {
                       
                        Spear.podiumSpearChangeSprite();
                            
                            Instantiate(knight_1);
                            knight_1.transform.position = new Vector2(-2, -2);
                            
                            destroyPlayer();
                        }
                    
                   
                        if (collision.gameObject.tag == "Podium_Sword")
                        {
                        print("allo");
                        Sword.podiumSwordChangeSprite();
                           
                            Instantiate(knight_3);
                            knight_3.transform.position = new Vector2(1, -2);
                            
                            destroyPlayer();
                        }
                     

                        if (collision.gameObject.tag == "Podium_Axe")
                        {
                            Axe.podiumAxeChangeSprite();
                            
                            Instantiate(knight_2);
                            knight_2.transform.position = new Vector2(4, -2);
                            
                            destroyPlayer();

                        }
                    

                    

                }
            }
        }
    }


    public void destroyPlayer()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

}



    

