using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Ennemie {
    [SerializeField] GameObject Meteor;
    [SerializeField] GameObject WallOfFire;
    bool wallOfFireCreate = false;
    float attackTimer = 0f;
    float meteorTimer = 0.3f;
    float letFireForm = 1f;
    float destroyedFireWallTimer = 1.5f;
    float meteorAttackTimer = 0f;
    bool startWallDestroy = false;
    bool isFireWallAttack = false;
    bool pushThePlayer = false;
    float pushThePlayerTimer = 1f;



    void Start () {
        InitializeInfo();
        resetImmunity();
        degat = 10;
	}
	
	// Update is called once per frame
	void Update () {
        
        pushPlayer();
        if (attackTimer <= 0)
        {
            attackTimer = 1500f;
            attack(getPattern());
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
        throwMeteor();
        FireWallAttack();
    }

    private void pushPlayer()
    {
        if (pushThePlayer)
        {
            GameObject.FindGameObjectWithTag("Player").transform.SetPositionAndRotation(new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x - .2f, GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.2f, GameObject.FindGameObjectWithTag("Player").transform.position.z),
            GameObject.FindGameObjectWithTag("Player").transform.rotation);
            updatePushTimer();
        }
    }

    private void updatePushTimer()
    {
        pushThePlayerTimer -= Time.deltaTime;
        if (pushThePlayerTimer < 0f)
        {
            pushThePlayer = false;
            pushThePlayerTimer = 1f;
        }
    }

    private void FireWallAttack()
    {
        
        if (isFireWallAttack)
        {
            if (!wallOfFireCreate)
            {
                GameObject WallOfFireClone = Instantiate(WallOfFire, new Vector3(GameObject.FindGameObjectWithTag("boss").transform.position.x - 2, GameObject.FindGameObjectWithTag("boss").transform.position.y, GameObject.FindGameObjectWithTag("boss").transform.position.z), gameObject.transform.rotation);
                wallOfFireCreate = true;

            }
            else
            {
                if (letFireForm <= 0)
                {
                    pushWall(GameObject.FindGameObjectWithTag("WallOfFire"));
                }
                else
                {
                    letFireForm -= Time.deltaTime;
                }

            }

        }


    }

    private int getPattern()
    {
        int rnd = UnityEngine.Random.Range(1, 10);
        return 1;
    }

    private void throwMeteor()
    {
        if(meteorAttackTimer > 0f)
        {
            if (meteorTimer <= 0f)
            {
              
                    GameObject meteorClone = Instantiate(Meteor, new Vector3(genererXPositionMeteorite(), genererYPositionMeteorite(), gameObject.transform.position.z), gameObject.transform.rotation);
                    meteorClone.tag = "MeteoriteClone";
                    meteorTimer = 0.3f;              
            }
            else
            {
                meteorTimer -= Time.deltaTime;
            }
        }
       
        meteorAttackTimer -= Time.deltaTime;
        
      
    }

    private float genererXPositionMeteorite()
    {
        float nouvellePositionX = 0;
        float positionXJoueur = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        nouvellePositionX = UnityEngine.Random.Range(positionXJoueur - 7, positionXJoueur+ 7);
        return nouvellePositionX;
    }
    private float genererYPositionMeteorite()
    {
        float nouvellePositionY = 0;
        float positionYJoueur = GameObject.FindGameObjectWithTag("Player").transform.position.y+15;
        nouvellePositionY = UnityEngine.Random.Range(positionYJoueur - 2, positionYJoueur + 2);
        return positionYJoueur;
    }

    public override void InitializeInfo()
    {
        startingHealth = 500;
        currentHealth = startingHealth;
    }

    public void attack(int pattern)
    {
        switch (pattern)
        {
            case 1:
                meteorAttackTimer = 1000f;
                break;
            case 2:
                isFireWallAttack=true;
                break;
            default:
                meteorAttackTimer = 10f;
                break;
        }
    }
    private void pushWall(GameObject wallOfFire)
    {
        wallOfFire.transform.SetPositionAndRotation(new Vector3(wallOfFire.transform.position.x -0.2f, wallOfFire.transform.position.y, wallOfFire.transform.position.z), wallOfFire.transform.rotation);
        destroyedFireWall(wallOfFire);
    }

    private void destroyedFireWall(GameObject wallOfFire)
    {
      
        if (destroyedFireWallTimer <= 0f)
        {
            isFireWallAttack = false;
            wallOfFireCreate = false;
            destroyedFireWallTimer = 1.5f;
            letFireForm = 1f;
            attackTimer = 5f;
            Destroy(wallOfFire);
            
        }
        else
        {
            wallOfFire.GetComponent<Animator>().SetTrigger("Destruction");
            destroyedFireWallTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "SwordCollider")
        {

            playSound();
            DealDamage(Player_Info.Degat);
            resetImmunity();
        }
            if (collision.tag == "Player")
            {
                print("eegregeg");
                pushThePlayer = true;
                
            }
        
    }

    public override void attackPlayer()
    {
        pushThePlayer = true;
        Player_Info.hit(degat);
    }
    public override void Dying()
    {
  
        Destroy();
    }
}
