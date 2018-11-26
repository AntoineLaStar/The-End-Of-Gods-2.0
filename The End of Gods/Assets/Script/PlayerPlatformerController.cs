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
    float PlayerInvisibleDelay = Player_Info.invisibilityDelay;
    float timeForNextInvisiblity;
    bool isShielded = false;
    bool isInvisible = false;
    public bool immunity = true;
    private float immunityTimeLeft;

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
        timeForNextInvisiblity = PlayerInvisibleDelay;
        resetImmunity();
    }

    protected override void ComputeVelocity()
    {
        immunityTimeLeft -= Time.deltaTime;
        timeForNextDash -= Time.deltaTime;
        timeForNextInvisiblity -= Time.deltaTime;
  
        if (timeForNextDash <= 0f)
        {
            Player_Info.ableToDash = true;
        }
        if (timeForNextInvisiblity <= 0f)
        {
            Player_Info.ableToInvisibility = true;
        }
        if (immunityTimeLeft <= 0f)
        {
            immunity = false;
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
                       
                        if (gameObject.name.Contains("knight_1"))
                        {
                            knight1Action();
                        }

                        if (gameObject.name.Contains("knight_2"))
                        {
                            knight2Action();
                        }

                        if (gameObject.name.Contains("knight_3"))
                        {
                            if (Player_Info.ableToInvisibility)
                            {
                                Player_Info.ableToInvisibility = false;
                                decreaseOpacity();
                                Invoke("cancelInvisibility", Player_Info.invisibilityLenght);
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

                    if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Attack"))
                    {
                   
                        if (HitTracker.HaveHit == false)
                        {
                                sound.PlaySound("Swoosh");
                              if (grounded == true)
                           {

                                    HitTracker.HaveHit = true;
                                    Invoke("delockAttack", Player_Info.attackDelay);
                                    animator.Play("knight_Attack");
                                }               
                        }
                    }
                    targetVelocity = move * maxSpeed;
                }
            }
            animator.SetFloat("speed", Mathf.Abs(velocity.x) / maxSpeed);
            animator.SetBool("grounded", grounded);

        
        }

        

        checkIfDefenceIsReleased();

    }
    public void delockAttack()
    {
        HitTracker.HaveHit = false;
    }


    public void knight1Action()
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

    public void knight2Action()
    {
        if (isShielded)
        {
            isShielded = false;
            increaseOpacity();
        }
        else
        {
            cancelCurrentPlayerAction();
            KeyImputManager.LockPlayerMouvement();
            isShielded = true;
            decreaseOpacity();
        }
    }

    public void cancelCurrentPlayerAction()
    {
        grounded = true;
        velocity.x = 0;
    }

    public void knight3Action()
    {
        if (Player_Info.ableToInvisibility)
        {
            decreaseOpacity();
            Invoke("cancelInvisibility", Player_Info.invisibilityLenght);
        }
    }

    public void checkIfDefenceIsReleased()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyUp(vKey))
            {
                keyPressed = vKey;
                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Defence") && gameObject.name.Contains("knight_2"))
                {
                    isInvisible = false;
                    increaseOpacity();
                    unlockPlayerMovement();
                }
            }
        }
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

    public void cancelInvisibility()
    {
        timeForNextInvisiblity = PlayerInvisibleDelay;
        increaseOpacity();
    }


    public void decreaseOpacity()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
    }

    public void increaseOpacity()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void resetImmunity()
    {
        immunityTimeLeft = Player_Info.immunityTime;
    }

    public void dealDamage(int amount)
    {
        Player_Info.currentHealth -= amount;
        playerHurtAnimation();
    }

    private void playerHurtAnimation()
    {
        animator.SetTrigger("hurt");
        KeyImputManager.LockPlayerMouvement();
        Invoke("unlockPlayerMovement", 0.1f);

    }

    public void unlockPlayerMovement()
    {
        KeyImputManager.freePlayerMouvement();
        rigidbody.velocity = Vector3.zero;
    }



}






        
    