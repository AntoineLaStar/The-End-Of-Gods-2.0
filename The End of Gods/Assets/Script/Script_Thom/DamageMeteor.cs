using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMeteor : MonoBehaviour {


    public void OnTriggerEnter2D(Collider other)
    {
        if (other.tag == "MeteoriteClone")
        {
            Player_Info.dealDamage(10);
        }
    }
}
