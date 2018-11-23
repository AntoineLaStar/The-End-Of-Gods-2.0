using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionWithPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CheckCollisionWithPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);

        if  (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].gameObject.name == "knight_base")
                {
                    print("awd;aoijfpowhef");
                }
            }
        }
    }
}
