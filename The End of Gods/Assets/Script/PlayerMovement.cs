using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] public float maxSpeed = 6;
    [SerializeField] public float speed = 50f;
    [SerializeField] public float jumpPower = 150f;

    public bool grounded =false;

    private Rigidbody2D rb2d;
    private Animator anim;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }

        if (Input.GetAxis("Jump") != 0 && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }

    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce((Vector2.right * speed)*h);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }


        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("CollisioneTuSacrament");

        Vector3 dir = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
        if (dir.y < 0)
        {
            grounded = true;
            print("Collision from bottom");
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        print("CollisioneTuSacrament");

        Vector3 dir = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
        if (dir.y < 0)
        {
            grounded = true;
            print("Collision from bottom");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
}
