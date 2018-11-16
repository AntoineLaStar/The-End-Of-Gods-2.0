using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : PhysicsObject
{
    KeyCode keyPressed = KeyCode.None;
    bool isGauche;
    private SpriteRenderer sprite;


    private ContactFilter2D contactFilterForPlayer;
    private RaycastHit2D[] hitBufferForPlayer = new RaycastHit2D[16];
    private List<RaycastHit2D> hitBufferListForPlayer = new List<RaycastHit2D>(16);

    void Awake () {
        sprite = GetComponent<SpriteRenderer>();
        contactFilterForPlayer.useTriggers = false;
        contactFilterForPlayer.SetLayerMask(Physics2D.GetLayerCollisionMask(13));
        contactFilterForPlayer.useLayerMask = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("test");
    }

    private void Update()
    {
        CheckCollisionWithPlayer();
    }

    private void CheckCollisionWithPlayer()
    {
       
       Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale);
        //print(hitColliders.Length);
        if (hitColliders.Length > 0)
        {
             print(hitColliders[0]);
            print("Hello");
        }
       
        
    }
    private void OnDrawGizmos()
    {
       Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (!KeyImputManager.getMouvementLock())
        {

            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {


                if (Input.GetKey(vKey))
                {
                    keyPressed = vKey;
                    if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Left"))
                    {

                        move.x = -1.0f;

                    }
                    else if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Right"))
                    {
                        move.x = 1.0f;
                    }



                    if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Left"))
                    {
                        if (isGauche == false)
                        {
                            sprite.flipX = !sprite.flipX;
                        }


                        isGauche = true;
                    }
                    else if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Right"))
                    {
                        if (isGauche == true)
                        {
                            sprite.flipX = !sprite.flipX;
                        }

                        isGauche = false;
                    }
                }
            }
        }


    }
}
