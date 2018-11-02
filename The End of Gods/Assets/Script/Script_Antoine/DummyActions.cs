using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyActions : MonoBehaviour {

    public bool isAttacked = false;
    Animator animator;
    GameObject hitsplat;
    [SerializeField] GameObject hitsplatPrefab;
	
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
        triggerHurtAnimation();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        stopHurtAnimation();
    }


    public void triggerHitSplat(int amount)
    {
        hitsplat = hitsplatPrefab;
        GameObject hitsplatClone = Instantiate(hitsplat, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void triggerHurtAnimation()
    {
        isAttacked = true;
        animator.Play("DummyHurt",-1,0f);
        Invoke("stopHurtAnimation", 1f);
    }

    public void stopHurtAnimation()
    {
        isAttacked = false;
        //animator.ResetTrigger("isAttacked");
    }
}
