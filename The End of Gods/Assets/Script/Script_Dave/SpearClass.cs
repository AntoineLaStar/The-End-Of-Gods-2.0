using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearClass
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void podiumSpearChangeSprite()
    {
        //print("lae");
        Sprite podium;
        podium = Resources.Load<Sprite>("podium");

        GameObject Spear = GameObject.FindGameObjectWithTag("Podium_Spear");

        //print("le");
        Spear.GetComponent<SpriteRenderer>().sprite = podium;
        
    }
}