using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonWithEnnemi : MonoBehaviour {

    GameObject player;
    bool ableToHit = true;
    float PlayerAttackDelay = Player_Info.attackDelay;
    float timeForNextAttack;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        timeForNextAttack = PlayerAttackDelay;
    }
	
	void Update () {
        timeForNextAttack -= Time.deltaTime;

        if (timeForNextAttack <= 0f)
        {
            ableToHit = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dummy" && ableToHit == true)
        {
            timeForNextAttack = Player_Info.attackDelay;
            ableToHit = false;
            collision.gameObject.GetComponent<DummyActions>().DealDamage(Player_Info.degat);
        }
       
    }
}
