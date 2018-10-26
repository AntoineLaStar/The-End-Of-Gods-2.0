using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Dummy_Info {

    public static int startingHealth = 999999999;
    public static float defence = 0.0f;
    public static int currentHealth = startingHealth;


    public static int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }




}
