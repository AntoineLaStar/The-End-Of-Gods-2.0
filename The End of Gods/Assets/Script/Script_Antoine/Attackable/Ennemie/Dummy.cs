using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Ennemie {
    Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public override void GiveMoney()
    {
        Player_Info.addMoney(1);
    }

    public override void InitializeInfo()
    {
        startingHealth = 1999;
        currentHealth = startingHealth;
    }

    public void triggerHurtAnimation()
    {
        animator.SetTrigger("IsAttacked");
    }
}
