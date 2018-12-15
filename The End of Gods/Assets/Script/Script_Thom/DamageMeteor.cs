using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMeteor : MonoBehaviour {



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player_Info.dealDamage(10 * Player_Info.ngPlus);
            
        }
    }
}
