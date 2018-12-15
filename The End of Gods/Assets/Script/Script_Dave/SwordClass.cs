using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordClass : MonoBehaviour {
    [SerializeField] GameObject knight_3;
    [SerializeField] Sprite PodiumSprite;
    [SerializeField] Sprite PodiumSpriteSword;
    [SerializeField] Sprite PodiumSpriteSpear;
    [SerializeField] Sprite PodiumSpriteAxe;
    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update() {
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
                        podiumSwordChangeSprite();
                        Instantiate(knight_3);
                        knight_3.transform.position = gameObject.transform.position;
                        Player_Info.setPlayerGameObject(knight_3);
                        Player_Info.CharacterName = knight_3.name;
                        HitTracker.HaveHit = false;
                        destroyPlayer();
                        
                    }

                }
            }
        }
    }
    



    public void podiumSwordChangeSprite()
    {

        Sprite podium;
        GameObject Sword = GameObject.FindGameObjectWithTag("Podium_Sword");
        podium = PodiumSprite;
        Sword.GetComponent<SpriteRenderer>().sprite = podium;

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
