using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class changeKey : MonoBehaviour {
    bool isWaitingForKey = false;
    KeyCode keyPressed = KeyCode.None;

    public void Update()
    {
        if (isWaitingForKey)
        {
            checkForKeyPresses();
        }

    }

    private void checkForKeyPresses()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                keyPressed = vKey;
                isWaitingForKey = false;
                updateKeyBind();
            }
        }
    }

    private void updateKeyBind()
    {
        KeyImputManager.SetKeyMap(EventSystem.current.currentSelectedGameObject.tag.ToString(), keyPressed);
        KeyImputManager.changeKeyMapHaveChange();
    }

    public void onClick()
    {
        isWaitingForKey = true;
        KeyImputManager.SaveActualKeyMapping();
    }
}
