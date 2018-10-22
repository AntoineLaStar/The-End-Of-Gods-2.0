using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyActions : MonoBehaviour {

    public bool isAttacked = false;
    Animator animator;
    GameObject hitsplat;
	
	void Start () {
        animator = gameObject.GetComponent<Animator>();
    }
	
	void Update () {

    }




    public void DealDamage(int amount)
    {
        Dummy_Info.CurrentHealth -= amount;
        triggerHitSplat(amount);
        isAttacked = true;
        animator.SetBool("isAttacked", isAttacked);
        
    }


    public void triggerHitSplat(int amount)
    {
        hitsplat = GameObject.FindGameObjectWithTag("HitSplat");
        GameObject hitsplatClone = Instantiate(hitsplat, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void triggerHurtAnimation()
    {
        isAttacked = true;
        animator.SetTrigger("isAttacked");
        animator.Play("isAttacked");
    }

    public void stopHurtAnimation()
    {
        animator.ResetTrigger("isAttacked");
        isAttacked = false;
    }
}
