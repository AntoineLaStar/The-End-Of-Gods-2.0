using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTeleporter : MonoBehaviour {
    [SerializeField] int linkScene;
   static string tag;
    static bool teleportHasBeenUsed = false;
	void Start () {
		
	}
	
   static public bool getTeleportHasBeenUsed()
    {
        return teleportHasBeenUsed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyUp(vKey))
            {
                KeyCode keyPressed = vKey;
                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("interact"))
                {
                    tag = gameObject.tag;
                    enterTeleporter();
                }
            }
        }
    }
    private void enterTeleporter()
    {
        if (TeleporterAccesManager.GetAccess(tag))
        {
        teleportHasBeenUsed = true;
        SceneManager.LoadScene(linkScene);
        }
        else
        {
            changeMessageState();
            DialogManager.RemoveMessage();


        }
    }
    static public void setTeleportHasBeenUsed()
    {
        teleportHasBeenUsed = !teleportHasBeenUsed;
    }
    static public string getTag()
    {
        return tag;
    }
    public void changeMessageState()
    {
        GetComponentInChildren<Canvas>().enabled = true;
    }
}
