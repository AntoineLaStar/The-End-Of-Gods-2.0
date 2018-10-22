using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordClass : MonoBehaviour {
    SpriteRenderer sr;
    public Sprite podium;
    // Use this for initialization
    void Start () {
         sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
    }

      




    public void podiumSwordChangeSprite()
    {
        
       // Sprite podium;
       // podium = Resources.Load<Sprite>("podium");

        GameObject Sword = GameObject.FindGameObjectWithTag("Podium_Sword");
        Sprite sprite = Resources.Load<Sprite>("Resources/Test/podium.png") ;
        print(Resources.LoadAll("Test")[0].name);
        // print(podium);
        print(sprite);
        sr.sprite = Resources.Load<Sprite>("Resources/Test/podium.png");
        
    }





}
