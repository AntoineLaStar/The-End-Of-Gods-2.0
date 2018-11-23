using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHealth : MonoBehaviour {

	// Use this for initialization
	void Awake() {
     
        
	}
	
	// Update is called once per frame
	void Update () {
        Player_Info.afficherHealth();
    }
}
