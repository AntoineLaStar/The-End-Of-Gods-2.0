using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Ennemie
{
    private void Start()
    {
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
        startingHealth = 99;
        degat = 0;
        attackDelay = 0f;
        attackDelayLeft = attackDelay;
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
