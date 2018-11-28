using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTeleporter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TeleporterAccesManager.lockAllTeleporter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
