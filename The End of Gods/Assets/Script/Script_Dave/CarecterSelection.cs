using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarecterSelection : MonoBehaviour
{

    [SerializeField] GameObject knight_1;
    [SerializeField] Sprite Podium;
    [SerializeField] Sprite PodiumSpriteSpear;

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
                    if (collision.gameObject.tag == "Player")
                    {


                        podiumSpearChangeSprite();


                    }
                }
            }
        }
    }


    public void podiumSpearChangeSprite()
    {
        Sprite Spear_podium;
        GameObject Spear = GameObject.FindGameObjectWithTag("Podium_Spear");
        Spear_podium = Podium;
        Spear.GetComponent<SpriteRenderer>().sprite = PodiumSpriteSpear;
    }


}



    

