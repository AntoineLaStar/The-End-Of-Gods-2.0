using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie : MonoBehaviour,Attackable {

    protected int currentHealth;
    protected int startingHealth;
    protected bool immunity = true;
    protected float immunityTime = 1f;
    protected float immunityTimeLeft;
    protected float attackDelay = 1f;
    protected float attackDelayLeft;
    protected int degat;
    protected bool dying = false;
    protected Animator animator;
    [SerializeField] GameObject hitsplatPrefab;
    GameObject hitsplat;

    public void GererImmunity()
    {
        immunityTimeLeft -= Time.deltaTime;

        if (immunityTimeLeft <= 0f)
        {
            immunity = false;
        }
    }

    protected void CheckCollisionWithPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].gameObject.tag == "SwordCollider")
                {
                    if (immunity == false)
                    {
                        playSound();
                        DealDamage(Player_Info.Degat);
                        resetImmunity();
                    }
                }

                if (hitColliders[i].gameObject.tag == "Player")
                {
                    if (!dying  && attackDelayLeft <= 0)
                    {
                        attackDelayLeft = attackDelay;
                        attackPlayer();
                    }
                }
            }
        }
    }

    public virtual void playSound()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    protected void resetImmunity()
    {
        immunityTimeLeft = immunityTime;
        immunity = true;
    }

    public virtual void GiveMoney()
    {
        Player_Info.addMoney(1000);
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        triggerHitSplat(damage);
        triggerHurtAnimation();
        if (currentHealth <= 0)
        {
            Dying();
        }
    }

    public virtual void attackPlayer()
    {
        Player_Info.hit(degat);
        playAttackAnimation();
    }

    public void Destroy()
    {
        GiveMoney();
        Destroy(gameObject);

    }

    public virtual void InitializeInfo()
    {
        startingHealth = 50;
        currentHealth = startingHealth;
        degat = 1;
        attackDelay = 2f;
        attackDelayLeft = attackDelay;
    }

    public void triggerHitSplat(int amount)
    {
        hitsplat = hitsplatPrefab;
        GameObject hitsplatClone = Instantiate(hitsplat, gameObject.transform.position, gameObject.transform.rotation);
    }

    public virtual void Dying()
    {
        stopMusic();
        DyingAnimation();
        Destroy();
    }

    public void decrementDelay()
    {
        attackDelayLeft -= Time.deltaTime;
    }

    public virtual void triggerHurtAnimation()
    {
        print("No hurt animation");
    }

    public virtual void DyingAnimation()
    {
    }

    public virtual void playAttackAnimation()
    {
    }
    public virtual void stopMusic()
    {
        
    }
}
