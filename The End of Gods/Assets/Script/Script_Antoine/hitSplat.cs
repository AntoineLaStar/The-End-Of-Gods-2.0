using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitSplat : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponentInChildren<Text>().text=Player_Info.Degat.ToString();

    }
	
	// Update is called once per frame
	void Update () {


		if (gameObject.GetComponent<CanvasGroup>().alpha > 0)
        {

            gameObject.GetComponent<CanvasGroup>().alpha -= 0.40f * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
