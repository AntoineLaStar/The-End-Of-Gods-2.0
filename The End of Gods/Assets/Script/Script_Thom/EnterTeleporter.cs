using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTeleporter : MonoBehaviour {
    [SerializeField] int linkScene;
    static bool teleportHasBeenUsed = false;
	void Start () {
		
	}
	
	void Update () {
		
	}
   static public bool getTeleportHasBeenUsed()
    {
        return teleportHasBeenUsed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                KeyCode keyPressed = vKey;
                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("interact"))
                {
                    enterTeleporter();
                }
            }
        }
    }
    private void enterTeleporter()
    {
        teleportHasBeenUsed = true;
        SceneManager.LoadScene(linkScene);
    }
    static public void setTeleportHasBeenUsed()
    {
        teleportHasBeenUsed = !teleportHasBeenUsed;
    }
}
