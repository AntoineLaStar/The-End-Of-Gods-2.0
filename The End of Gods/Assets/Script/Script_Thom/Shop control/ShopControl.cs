using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControl : MonoBehaviour {

public void buyHealth()
    {
        Player_Info.BuyHealth();
        print(Player_Info.startingHealth);
    }
    public void buyDefence()
    {
        Player_Info.BuyDefence();
        print(Player_Info.defence);
    }
    public void buyDegat()
    {
        Player_Info.BuyDamage();
        print(Player_Info.degat);
    }
}
