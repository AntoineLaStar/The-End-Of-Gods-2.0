using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearClass : MonoBehaviour
{
    [SerializeField] GameObject knight_1;
    [SerializeField] Sprite PodiumSprite;
    [SerializeField] Sprite PodiumSpriteSpear;
    [SerializeField] Sprite PodiumSpriteSword;
    [SerializeField] Sprite PodiumSpriteAxe;
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

                        Instantiate(knight_1);
                        knight_1.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;

                        destroyPlayer();

                    }
                }
            }
        }
    }

    public void podiumSpearChangeSprite()
    {
        Sprite podium;
        GameObject Spear = GameObject.FindGameObjectWithTag("Podium_Spear");
        podium = PodiumSprite;
        Spear.GetComponent<SpriteRenderer>().sprite = podium;

    }
    public void destroyPlayer()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }


    public void  podiumReset()
    {

        GameObject Spear = GameObject.FindGameObjectWithTag("Podium_Spear");
        GameObject Sword = GameObject.FindGameObjectWithTag("Podium_Sword");
        GameObject Axe = GameObject.FindGameObjectWithTag("Podium_Axe");

        Spear.GetComponent<SpriteRenderer>().sprite = PodiumSpriteSpear;
         Sword.GetComponent<SpriteRenderer>().sprite = PodiumSpriteSword;
         Axe.GetComponent<SpriteRenderer>().sprite = PodiumSpriteAxe;
    }
}