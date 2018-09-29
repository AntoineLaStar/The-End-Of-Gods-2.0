using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public string currentClass = "";

    public GameObject knight_1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
                    if (collision.gameObject.tag == "Podium_Spear")
                    {
                        Instantiate(knight_1);
                        destroyPlayer();
                        createCaracter();

                        podiumSpearDestroy();
                        currentClass = "Podium_Spear";
                    }
                }
            }
        }



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

    public void podiumSpearDestroy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Podium_Spear"));
    }

}