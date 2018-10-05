using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAnimation : MonoBehaviour {

    public bool isAttacked = false;
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isAttacked = true;
        animator.SetTrigger("isAttacked");
        animator.Play("isAttacked");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.ResetTrigger("isAttacked");
    }
}
