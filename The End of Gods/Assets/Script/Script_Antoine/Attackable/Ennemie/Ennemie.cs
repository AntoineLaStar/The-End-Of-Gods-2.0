using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie : MonoBehaviour,Attackable {

    protected int currentHealth;
    protected int startingHealth;
    protected bool immunity = true;
    protected float immunityTime = 1f;
    protected float immunityTimeLeft;
    protected int degat;
    [SerializeField] GameObject hitsplatPrefab;
    GameObject hitsplat;

    void Start () {
        InitializeInfo();
        resetImmunity();
    }
	
	// Update is called once per frame
	void Update () {
        GererImmunity();
        CheckCollisionWithPlayer();
    }

    private void GererImmunity()
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
                    attackPlayer();
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
        Player_Info.addMoney(0);
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        triggerHitSplat(damage);
        if (currentHealth <= 0)
        {
            Destroy();
        }
    }

    public virtual void attackPlayer()
    {
        PlayerPlatformerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        if (player.immunity == false)
        {
            player.dealDamage(degat);
            player.resetImmunity();
            player.immunity = true;
        }
    }


    public void Destroy()
    {
        GiveMoney();
        DyingAnimation();
        Destroy(gameObject);
    }

    public virtual void InitializeInfo()
    {
        startingHealth = 50;
        currentHealth = startingHealth;
    }

    public void triggerHitSplat(int amount)
    {
        hitsplat = hitsplatPrefab;
        GameObject hitsplatClone = Instantiate(hitsplat, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void DyingAnimation()
    {

    }
}
