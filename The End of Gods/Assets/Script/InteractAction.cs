using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAction : MonoBehaviour {
    KeyCode keyPressed = KeyCode.None;

    public Transform popupbox;
    public static string textstatus = "off";


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (textstatus == "off")
        {
            popupbox.GetComponent<TextMesh>().text = KeyImputManager.GetKeyBind("interact");
            textstatus = "on";
            //Instantiate(popupbox, new Vector3(transform.position.x, transform.position.y, 0));

        }

        //GameObject InterfaceInteract = new GameObject();
        //InterfaceInteract.AddComponent<>();
        //InterfaceInteract.GetComponent<SpriteRenderer>().;
        //Vector3 positionFromMainObject = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //InterfaceInteract.transform.position = positionFromMainObject;
        //string test = KeyImputManager.GetKeyBind("interact");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
