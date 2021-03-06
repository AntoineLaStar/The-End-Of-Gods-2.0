﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class KeyDisplayer : MonoBehaviour {
    public Text Left, Right, DashLeft, DashRight, Jump, interact,Attack, Defence,Pause;
    // Use this for initialization
    void  Start () {
        if (!KeyImputManager.getIsInitialize())
        {
        KeyImputManager.KeyInputManager();
        }
        
        Left.text = KeyImputManager.GetKeyBind("Left");
        Right.text = KeyImputManager.GetKeyBind("Right");
        DashLeft.text = KeyImputManager.GetKeyBind("DashLeft");
        DashRight.text = KeyImputManager.GetKeyBind("DashRight");
        Jump.text = KeyImputManager.GetKeyBind("Jump");
        interact.text = KeyImputManager.GetKeyBind("interact");
        Attack.text = KeyImputManager.GetKeyBind("Attack");
        Defence.text = KeyImputManager.GetKeyBind("Defence");
        Pause.text = KeyImputManager.GetKeyBind("Pause");
    }


    // Update is called once per frame
    void Update () {
        if (KeyImputManager.getKeyMapHasChange())
        {
            Left.text = KeyImputManager.GetKeyBind("Left");
            Right.text = KeyImputManager.GetKeyBind("Right");
            DashLeft.text = KeyImputManager.GetKeyBind("DashLeft");
            DashRight.text = KeyImputManager.GetKeyBind("DashRight");
            Jump.text = KeyImputManager.GetKeyBind("Jump");
            interact.text = KeyImputManager.GetKeyBind("interact");
            Attack.text = KeyImputManager.GetKeyBind("Attack");
            Defence.text = KeyImputManager.GetKeyBind("Defence");
            Pause.text = KeyImputManager.GetKeyBind("Pause");
            KeyImputManager.changeKeyMapHaveChange();

        }
	}
    
}
