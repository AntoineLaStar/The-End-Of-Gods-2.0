using UnityEngine;
using System;
using System.Collections;

public class MouvementEnnemie : MonoBehaviour {
    [SerializeField] public float speed = 1f;
    [SerializeField] public float minDistance = 5f;
    bool spriteIsGauche = false;
    GameObject player;
    Transform target;  
    float range;

    void Start()
    {

    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;

        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            gameObject.GetComponent<Animator>().SetBool("moving",true);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x,transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }

        verifierSprite();
    }

    private void verifierSprite()
    {
        if (target.position.x > transform.position.x && spriteIsGauche == false)
        {
            flipSprite();
            spriteIsGauche = true;
        }
        else if (target.position.x < transform.position.x && spriteIsGauche == true)
        {
            flipSprite();
            spriteIsGauche = false;
        }
    }

    private void flipSprite()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
