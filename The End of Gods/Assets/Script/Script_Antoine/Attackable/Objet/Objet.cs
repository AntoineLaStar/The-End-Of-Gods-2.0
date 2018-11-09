using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objet : MonoBehaviour, Attackable
{

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void DealDamage(int damage)
    {
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
}
