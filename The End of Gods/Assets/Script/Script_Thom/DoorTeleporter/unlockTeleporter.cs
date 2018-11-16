using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockTeleporter : MonoBehaviour {

    [SerializeField] Canvas unlockMessage;
    [SerializeField] string tpTag;
    private static bool messagehaveBeenShowen = false;

    private void Update()
    {
        if (messagehaveBeenShowen)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyUp(vKey))
                {
                    if (vKey.ToString() == KeyImputManager.GetKeyBind("interact").ToString())
                    {
                        unlockMessage.enabled = false;
                    }

                }

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        

        if (!messagehaveBeenShowen)
        {
            if (collision.tag == "Player")
            {
                if (!TeleporterAccesManager.GetAccess(tpTag))
                {
                    TeleporterAccesManager.unlockTeleporteur(tpTag);
                    TeleporteurInfoController.teleporteurInfoController.SaveGame();
                }
                showUnlockMessage();

            }
        }
    }

    private void showUnlockMessage()
    {
        unlockMessage.enabled = true;
        messagehaveBeenShowen = true;
    }
}


