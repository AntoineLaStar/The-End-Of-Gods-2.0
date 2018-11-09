using System.Collections;
using System.Collections.Generic;
using System;

public class Barrel : Objet
{
    public override void AddCoinToPlayer()
    {
        Random r = new Random();
        int rnd = r.Next(10, 50);
        Player_Info.addMoney(rnd);
    }
}
