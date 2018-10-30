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




}
