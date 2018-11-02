using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonWithEnnemi : MonoBehaviour
{

    KeyCode keyPressed = KeyCode.None;
    GameObject player;
  
    float PlayerAttackDelay = Player_Info.attackDelay;
   
    bool attack;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Player_Info.timeForNextAttack = PlayerAttackDelay;
        
    }
	
	void Update () {
        Player_Info.timeForNextAttack -= Time.deltaTime;

        if (Player_Info.timeForNextAttack <= 0f)
        {
            Player_Info.ableToHit = true;
        }

        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                keyPressed = vKey;

                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Attack"))
                {
                    gameObject.GetComponent<Collider2D>().enabled = true;
                    Invoke("enableColliderWeapon", 0.5f);
                   
                }

            }
        }

    }

    private void enableColliderWeapon()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dummy" && Player_Info.ableToHit == true)
        {
            Player_Info.timeForNextAttack = Player_Info.attackDelay;
            Player_Info.ableToHit = false;
            collision.gameObject.GetComponent<DummyActions>().DealDamage(Player_Info.degat);
        }
        
    }

    
}
