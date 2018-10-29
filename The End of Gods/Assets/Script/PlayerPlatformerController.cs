using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
    KeyCode keyPressed = KeyCode.None;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 12;
    public bool isAttacking = false;
    public bool ableToDash = true;
    float PlayerDashDelay = Player_Info.dashDelay;
    float timeForNextDash;
    bool isInvisible = false;

    private Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rigidbody;
    Collider2D test;

    bool isGauche;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        timeForNextDash = PlayerDashDelay;
    }

    protected override void ComputeVelocity()
    {
        timeForNextDash -= Time.deltaTime;

        if (timeForNextDash <= 0f)
        {
            Player_Info.ableToDash = true;
        }

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

                    if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Jump") && grounded)
                    {
                        velocity.y = jumpTakeOffSpeed;

                    }
                    else if (Input.GetKeyUp(KeyImputManager.GetKeyBind("Jump").ToLower()))
                    {
                        if (velocity.y > 0)
                        {
                            velocity.y = velocity.y * 0.5f;

                        }
                    }

                    if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Defence"))
                    {
                        if (gameObject.name == "knight_1")
                        {
                            if (Player_Info.ableToDash == true)
                            {
                                playerDash();
                                KeyImputManager.LockPlayerMouvement();
                                Invoke("unlockPlayerMovement", Player_Info.dashLenght);
                                Player_Info.ableToDash = false;
                                timeForNextDash = PlayerDashDelay;
                            }
                        }

                        if (gameObject.name == "knight_2")
                        {
                                if (isInvisible)
                                {
                                    isInvisible = false;
                                    increaseOpacity();
                                }
                                else
                                {
                                    KeyImputManager.LockPlayerMouvement();
                                    isInvisible = true;
                                    decreaseOpacity();
                                }
                        }

                        if (gameObject.name == "knight_3")
                        {
                            if (isInvisible)
                            {
                                isInvisible = false;
                                increaseOpacity();
                            }
                            else
                            {
                                KeyImputManager.LockPlayerMouvement();
                                isInvisible = true;
                                decreaseOpacity();
                                animator.Play("knight_2_Idle");
                            }
                        }

                    }



                    if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Left"))
                    {
                        if (isGauche == false)
                        {
                            test = GameObject.FindGameObjectWithTag("SwordCollider").GetComponent<Collider2D>();
                            sprite.flipX = !sprite.flipX;
                            test.offset *= -1;
                        }


                        isGauche = true;
                    }
                    else if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Right"))
                    {
                        if (isGauche == true)
                        {
                            test = GameObject.FindGameObjectWithTag("SwordCollider").GetComponent<Collider2D>();
                            sprite.flipX = !sprite.flipX;
                            test.offset *= -1;
                        }

                        isGauche = false;
                    }

                    targetVelocity = move * maxSpeed;
                }
            }
       
        animator.SetFloat("speed", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetBool("grounded", grounded);
        }


        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyUp(vKey))
            {
                keyPressed = vKey;
                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Defence"))
                {
                    isInvisible = false;
                    increaseOpacity();
                    unlockPlayerMovement();
                }

            }
        }

    }




    public void unlockPlayerMovement()
    {
        KeyImputManager.freePlayerMouvement();
        rigidbody.velocity = Vector3.zero;
    }

    public void playerDash()
    {
        if (Player_Info.ableToDash == true)
        {
            if (!isGauche)
            {
                animator.Play("knight_1_Dash");
                rigidbody.AddForce(new Vector2(-Player_Info.dashForce, 0), ForceMode2D.Impulse);
            }
            else
            {
                animator.Play("knight_1_Dash");
                rigidbody.AddForce(new Vector2(Player_Info.dashForce, 0), ForceMode2D.Impulse);
            }
            Player_Info.ableToDash = false;
        }
    }

    public void decreaseOpacity()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
    }

    public void increaseOpacity()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }





}
        
    