using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie1 : Ennemie {

    public override void GiveMoney()
    {
        Player_Info.addMoney(200);
    }

    public override void InitializeInfo()
    {
       startingHealth = 100;
       currentHealth = startingHealth;
    }
}
