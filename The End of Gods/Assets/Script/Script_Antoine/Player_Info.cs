using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player_Info {
    public static int startingHealth = 100;
    public static int currentHealth ;
    public static float defence = 0.0f;
    public static int degat = 10;

    public static float attackDelay = 1;
    public static bool ableToHit = true;
    public static float timeForNextAttack = 0.0f;
    public static GameObject character;
    public static string characterName; 
    public static int dashForce = 15;
    public static float dashLenght = 0.3f;
    public static float dashDelay = 1;
    public static bool ableToDash = true;

    public static float invisibilityLenght = 2;
    public static float invisibilityDelay = 3;
    public static bool ableToInvisibility = true;

    public static int CurrentHealth
    {
        set { currentHealth = value; }
    }

    public static GameObject Character
    {
        get { return character; }
        set { character = value;  }
    }


    public static string CharacterName
    {
        get { return characterName; }
        set { characterName = value; }
    }

    public static void BuyHealth()
    {
        
        startingHealth +=(Mathf.RoundToInt(startingHealth * 0.05f));
    }
    public static void BuyDefence()
    {
        int defToAdd = (Mathf.RoundToInt(defence * 0.05f));
        if (defToAdd < 1)
        {
            defToAdd = 1;
        }
        defence += defToAdd;
    }
    public static void BuyDamage()
    {
        int dmgToAdd = (Mathf.RoundToInt(degat * 0.05f));
        if (dmgToAdd < 1)
        {
            dmgToAdd = 1;
        }
        degat += dmgToAdd;
    }

    public static void setPlayerGameObject(GameObject thePlayer)
    {
        character = thePlayer;
       
    }


}
