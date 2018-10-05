using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Info : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;

    PlayerPlatformerController PlayerMovement;

    void Awake()
    {
        PlayerMovement = GetComponent<PlayerPlatformerController>();
        currentHealth = startingHealth;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
