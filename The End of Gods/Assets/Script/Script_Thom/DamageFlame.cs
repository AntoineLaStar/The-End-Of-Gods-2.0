using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlame : MonoBehaviour {
    bool pushThePlayer = false;
    float pushThePlayerTimer = 1f;
    public void Update()
    {
        if (pushThePlayer)
        {
            pushPlayer();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            Player_Info.dealDamage(25);
            pushThePlayer = true;
        }
    }
    private void pushPlayer()
    {
        if (pushThePlayer)
        {
  
            GameObject.FindGameObjectWithTag("Player").transform.SetPositionAndRotation(new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x - .2f, GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.2f, GameObject.FindGameObjectWithTag("Player").transform.position.z),
            GameObject.FindGameObjectWithTag("Player").transform.rotation);
            updatePushTimer();
        }
    }

    private void updatePushTimer()
    {
        pushThePlayerTimer -= Time.deltaTime;
        if (pushThePlayerTimer < 0f)
        {
      
            pushThePlayer = false;
            pushThePlayerTimer = 1f;

        }
    }

}
