using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie2 : Ennemie {

    public override void GiveMoney()
    {
        Player_Info.addMoney(250);
    }

    public override void InitializeInfo()
    {
        startingHealth = 150;
        currentHealth = startingHealth;
    }
}
