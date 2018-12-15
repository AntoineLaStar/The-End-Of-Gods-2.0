using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Ennemie
{
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
    }

    public override void GiveMoney()
    {
        Player_Info.addMoney(1);
    }

    public override void InitializeInfo()
    {
        startingHealth = 999999;
        degat = 0;
        currentHealth = startingHealth;
    }

    public override void triggerHurtAnimation()
    {
        animator.SetTrigger("attacked");
    }

    public override void attackPlayer()
    {

    }
}
