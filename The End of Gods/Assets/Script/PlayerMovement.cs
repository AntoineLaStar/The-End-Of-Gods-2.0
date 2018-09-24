using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] public float maxSpeed = 6;
    [SerializeField] public float speed = 50f;
    [SerializeField] public float jumpPower = 450f;
    KeyCode keyPressed = KeyCode.None;
    public bool grounded = false;

    private Rigidbody2D rb2d;
    private Animator anim;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {

        
                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Left"))
                {
                    
                    transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
                }
                else if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Right"))
                {
                    transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }

                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Jump") && grounded)
                {
                    rb2d.AddForce(Vector2.up * jumpPower);
                    grounded = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var normal = collision.contacts[0].normal;
        if (normal.y > 0)
        {
            grounded = true;
        }
    }




}
