using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearClass : MonoBehaviour
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
       
        Sprite podium;
       

        GameObject Spear = GameObject.FindGameObjectWithTag("Podium_Spear");

        podium = Resources.Load<Sprite>("podium");
        Spear.GetComponent<SpriteRenderer>().sprite = podium;
        
    }
}