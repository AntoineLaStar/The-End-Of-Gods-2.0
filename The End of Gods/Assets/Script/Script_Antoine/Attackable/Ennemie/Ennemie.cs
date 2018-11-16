using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie : MonoBehaviour,Attackable {

    protected int currentHealth;
    protected int startingHealth;


	void Start () {
        InitializeInfo();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SwordCollider")
        {
            DealDamage(Player_Info.degat);
            print(currentHealth);
        }
    }


    public virtual void GiveMoney()
    {
        Player_Info.addMoney(0);
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        GiveMoney();
        DyingAnimation();
    }

    public virtual void InitializeInfo()
    {
        startingHealth = 50;
        currentHealth = startingHealth;
    }

    public void DyingAnimation()
    {
        while (gameObject.GetComponent<CanvasGroup>().alpha > 0)
        {

            gameObject.GetComponent<CanvasGroup>().alpha -= 0.50f * Time.deltaTime;
        }

        if (gameObject.GetComponent<CanvasGroup>().alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
