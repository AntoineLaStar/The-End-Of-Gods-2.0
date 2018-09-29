using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarecterSelection : MonoBehaviour {
    public GameObject knight_1;
    public GameObject knight_2;
    public GameObject knight_3; 
    public bool spearTaken = false;
    public bool swordTaken = false;
    public bool axeTaken = false;
    public string currentClass = "";
    
    // Use this for initialization
    void Start () {
        
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        KeyCode keyPressed = KeyCode.None;
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                keyPressed = vKey;

                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("interact"))
                {
                    
                    if (collision.gameObject.tag == "Podium_Spear" && spearTaken == false)
                    {
                        
                            Instantiate(knight_1);
                            
                            spearTaken = true;
                            axeTaken = false;
                            swordTaken = false;
                        destroyPlayer();
                        createCaracter();
                            
                            podiumSpearDestroy();
                            currentClass = "Podium_Spear";
                    }
                    else if (collision.gameObject.tag == "Podium_Sword" && swordTaken == false)
                    {                
                            Instantiate(knight_2);
                            swordTaken = true;
                            spearTaken = false;
                            axeTaken = false;
                        destroyPlayer();
                        createCaracter();
                            
                            podiumSWordDestroy();
                            currentClass = "Podium_Sword";
                    }
                    else if (collision.gameObject.tag == "Podium_Axe" && axeTaken == false)
                    {
                            Instantiate(knight_3);
                            axeTaken = true;
                            spearTaken = false;
                            swordTaken = false;
                        destroyPlayer();
                        createCaracter();
                           
                            podiumAxeDestroy();
                            currentClass = "Podium_Axe";
                    }
                }
            }
        }
    }


    public void podiumSpearDestroy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Podium_Spear"));
    }


    public void podiumSWordDestroy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Podium_Sword"));
    }


    public void podiumAxeDestroy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Podium_Axe"));
    }

    public void destroyPlayer()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
       
    }

    public void createCaracter()
    {
        if (currentClass != "")
        {
            Instantiate(GameObject.FindGameObjectWithTag(currentClass));
        }
    }
}



    

