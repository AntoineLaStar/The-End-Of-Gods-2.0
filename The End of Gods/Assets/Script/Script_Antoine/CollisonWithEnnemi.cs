using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonWithEnnemi : MonoBehaviour
{

    KeyCode keyPressed = KeyCode.None;
    float PlayerAttackDelay = Player_Info.attackDelay;
   
    bool attack;

    void Start () {
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


    
}
