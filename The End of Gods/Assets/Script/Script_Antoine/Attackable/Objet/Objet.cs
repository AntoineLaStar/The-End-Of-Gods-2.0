using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objet : MonoBehaviour, Attackable
{
    protected bool isDestroyed;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        CheckCollisionWithPlayer();

    }

    public virtual void DealDamage(int damage)
    {
        isDestroyed = true;
        AddCoinToPlayer();
        PlaySound();
        Invoke("Destroy", 0.2f);
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public virtual void AddCoinToPlayer()
    {
        
    }

    protected void CheckCollisionWithPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);

        if (hitColliders.Length > 0 && isDestroyed == false)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].gameObject.tag == "SwordCollider")
                {
                        DealDamage(Player_Info.Degat);
                }
            }
        }
    }
}
