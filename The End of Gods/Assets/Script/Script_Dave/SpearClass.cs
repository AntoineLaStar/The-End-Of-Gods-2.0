using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearClass : MonoBehaviour
{
    [SerializeField] GameObject knight_1;
    [SerializeField] Sprite PodiumSprite;
    [SerializeField] Sprite PodiumSpriteSpear;
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
                        podiumSpearChangeSprite();

                        Instantiate(knight_1);
                        knight_1.transform.position = new Vector2(-2, -2);

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
}