using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player_Info {
    public static int startingHealth = 100;
    public static int currentHealth ;
    public static float defence = 0.0f;
    public static int degat = 10;
    public static float attackDelay = 0;


    public static int CurrentHealth
    {
        set { currentHealth = value; }
    }




}
