using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie2 : Ennemie {
    [SerializeField] public float speed = 1f;
    [SerializeField] public float minDistance = 5f;
    bool spriteIsGauche = false;
    GameObject player;
    Transform target;
    float range;


    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        InitializeInfo();
        resetImmunity();
    }

    private void Update()
    {
        GererImmunity();
        CheckCollisionWithPlayer();
        mouvement();
        decrementDelay();
    }

    public void mouvement()
    {
        if (!dying)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            target = player.transform;
            range = Vector2.Distance(transform.position, target.position);

            if (range > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
                animator.SetBool("Walking",true);
            }
            else
            {
                animator.SetBool("Walking", false);
            }


            CheckCollisionWithPlayer();
            verifierSprite();
        }
    }

    public override void GiveMoney()
    {
        Player_Info.addMoney(250);
    }

    public override void InitializeInfo()
    {
        startingHealth = 150;
        currentHealth = startingHealth;
        degat = 15;
        attackDelay = 0.75f;
        attackDelayLeft = attackDelay;
    }

    private void verifierSprite()
    {
        if (target.position.x > transform.position.x && spriteIsGauche == false)
        {
            flipSprite();
            spriteIsGauche = true;
        }
        else if (target.position.x < transform.position.x && spriteIsGauche == true)
        {
            flipSprite();
            spriteIsGauche = false;
        }
    }

    public override void playAttackAnimation()
    {
        animator.SetTrigger("Attacking");
    }

    private void flipSprite()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public override void Dying()
    {
        DyingAnimation();
        Invoke("Destroy",1f);
    }

    public override void DyingAnimation()
    {
        dying = true;
        animator.SetTrigger("Dying");
    }
}
