using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using System.IO;
using System;

public static class Player_Info
{

    public static int startingHealth = 100;
    public static int currentHealth= startingHealth;
    public static float defence = 0.0f;
    public static int degat = 75;
    public static int money = 500;

    public static float attackDelay = 1;
    public static bool ableToHit = true;
    public static float timeForNextAttack = 0.0f;
    public static GameObject character;
    public static string characterName;
    public static int dashForce = 15;
    public static float dashLenght = 0.3f;
    public static float dashDelay = 1;
    public static bool ableToDash = true;
    public static float immunityTime = 1.5f;
    public static bool grounded;

    public static float invisibilityLenght = 2;
    public static float invisibilityDelay = 3;
    public static bool ableToInvisibility = true;
    public static int ngPlus = 1;

    public enum Background { hell, outside, castle };
    public static Background background = Background.hell;

    public static int CurrentHealth
    {
        set { currentHealth = value; }
    }

    public static GameObject Character
    {
        get { return character; }
        set { character = value; }
    }


    public static string CharacterName
    {
        get { return characterName; }
        set { characterName = value; }
    }

    public static int Degat
    {
        get { return degat; }
    }

    public static void BuyHealth()
    {

        startingHealth += (Mathf.RoundToInt(startingHealth * 0.05f));
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

    public static int Money
    {
        get { return money; }
    }
    public static int NgPlus
    {
        get { return ngPlus; }
    }

    public static void reduceMoney(int moneyToRemove)
    {
        money -= moneyToRemove;
    }

    public static void addMoney(int amount)
    {
        money += amount;
        afficherMoney();
    }

    public static void increaseNgPlus()
    {
        ngPlus++;
    }

    public static void afficherMoney()
    {
      
        GameObject.FindGameObjectWithTag("coin").GetComponent<Text>().text = Player_Info.money.ToString();
    }

    public static void afficherHealth()
    {
        GameObject.FindGameObjectWithTag("heart").GetComponent<Text>().text = Player_Info.currentHealth.ToString();
    }

    public static void hit(int ennemyDamage)
    {
        PlayerPlatformerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        if (player.immunity == false && player.isShielded == false && player.isInvisible == false)
        {
            player.dealDamage(ennemyDamage);
            player.resetImmunity();
            player.immunity = true;
        }
    }
    public static void dealDamage(int degat)
    {
        hit(degat);
    }


}
