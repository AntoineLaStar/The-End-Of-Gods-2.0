using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dummy_Info : MonoBehaviour {

    public int startingHealth = 999999999;
    public float defence = 0.0f;
    public int currentHealth;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 1f);

    // Use this for initialization
    bool damage;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (damage)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damage = false;
	}

    public void DealDamage(int amount)
    {
        damage = true;
        currentHealth -= amount;
    }




}
