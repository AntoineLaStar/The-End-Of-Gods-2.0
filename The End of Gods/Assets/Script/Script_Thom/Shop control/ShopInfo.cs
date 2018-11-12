using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShopInfo {

    private static int healthPrice = 0;
    private static int defencePrice = 500;
    private static int attackPrice = 500;


    public static int HealthPrice
    {
        get { return healthPrice; }
        set { healthPrice = value; }
    }

    public static int DefencePrice
    {
        get { return defencePrice; }
        set { defencePrice = value; }
    }

    public static int AttackPrice
    {
        get { return attackPrice; }
        set { attackPrice = value; }
    }

    public static void incrementHealth()
    {
        healthPrice += 500;
    }

    public static void incrementDefence()
    {
        defencePrice += 500;
    }

    public static void incrementAttack()
    {
        attackPrice += 500;
    }
}
