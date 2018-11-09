using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    [SerializeField] public Sprite spritePodiumVide;
    [SerializeField] public Sprite spritePodiumArme;
    [SerializeField] public GameObject knight;
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
                        PodiumResetAll();
                        SetPlayer();
                        DestroyPlayer();

                    }

                }
            }
        }
    }

    public void PodiumResetAll()
    {

        GameObject Spear = GameObject.FindGameObjectWithTag("Podium_Spear");
        GameObject Sword = GameObject.FindGameObjectWithTag("Podium_Sword");
        GameObject Axe = GameObject.FindGameObjectWithTag("Podium_Axe");

        Spear.GetComponent<Weapon>().PodiumReset();
        Sword.GetComponent<Weapon>().PodiumReset();
        Axe.GetComponent<Weapon>().PodiumReset();
    }

    public void PodiumReset()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spritePodiumArme;
    }

    public void DestroyPlayer()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public virtual void SetPlayer()
    {
        PodiumSwordChangeSprite();
        Instantiate(knight);
        knight.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        Player_Info.setPlayerGameObject(knight);
        Player_Info.CharacterName = knight.name;
    }


    public void PodiumSwordChangeSprite()
    {


        gameObject.GetComponent<SpriteRenderer>().sprite = spritePodiumVide;

    }
}