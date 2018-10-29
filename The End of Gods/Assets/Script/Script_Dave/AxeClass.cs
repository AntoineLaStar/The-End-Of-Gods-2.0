using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AxeClass : MonoBehaviour {

    [SerializeField] GameObject knight_2;
    [SerializeField] Sprite PodiumSprite;
    [SerializeField] Sprite PodiumSpriteAxe;
    [SerializeField] Sprite PodiumSpriteSpear;
    [SerializeField] Sprite PodiumSpriteSword;

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

                        podiumReset();
                        podiumSpearChangeSprite();                
                        Instantiate(knight_2);
                        knight_2.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                        destroyPlayer();

                    }
                }
            }
        }
    }

    public void podiumSpearChangeSprite()
    {
        Sprite podium;
        GameObject Spear = GameObject.FindGameObjectWithTag("Podium_Axe");
        podium = PodiumSprite;
        Spear.GetComponent<SpriteRenderer>().sprite = podium;

    }
    public void destroyPlayer()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }


    public void podiumReset()
    {

        GameObject Spear = GameObject.FindGameObjectWithTag("Podium_Spear");
        GameObject Sword = GameObject.FindGameObjectWithTag("Podium_Sword");
        GameObject Axe = GameObject.FindGameObjectWithTag("Podium_Axe");

        Spear.GetComponent<SpriteRenderer>().sprite = PodiumSpriteSpear;
        Sword.GetComponent<SpriteRenderer>().sprite = PodiumSpriteSword;
        Axe.GetComponent<SpriteRenderer>().sprite = PodiumSpriteAxe;
    }
}