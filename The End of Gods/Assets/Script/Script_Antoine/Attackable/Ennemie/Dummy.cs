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
        startingHealth = 999999;
        currentHealth = startingHealth;
    }

    public void triggerHurtAnimation()
    {
        animator.SetTrigger("IsAttacked");
    }

}
