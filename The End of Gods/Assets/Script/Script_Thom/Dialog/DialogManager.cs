using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    static bool DialogIsShowen;

    static public void RemoveMessage()
    {
        while (DialogIsShowen)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyUp(vKey))
                {
                    changeDialogState();
                }

            }
        }
    }

   static private void changeDialogState()
    {
        DialogIsShowen = !DialogIsShowen;
    }
}
