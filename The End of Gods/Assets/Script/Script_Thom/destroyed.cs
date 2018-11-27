using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyed : MonoBehaviour {

    float timeUntilDestroction = 3f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.tag != "MeteoriteDeBase")
        {
            if (timeUntilDestroction <= 0f)
            {
                Destroy(gameObject);
            }
            else
            {
                timeUntilDestroction -= Time.deltaTime;
            }
        }
        
	}
}
