using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDisplayer : MonoBehaviour {
    public Text Left, Right, DashLeft, DashRight, Jump, interact;
    // Use this for initialization
    void Start () {
        KeyImputManager.KeyInputManager();
        Left.text = KeyImputManager.GetKeyBind("Left");
        Right.text = KeyImputManager.GetKeyBind("Right");
        DashLeft.text = KeyImputManager.GetKeyBind("DashLeft");
        DashRight.text = KeyImputManager.GetKeyBind("DashRight");
        Jump.text = KeyImputManager.GetKeyBind("Jump");
        interact.text = KeyImputManager.GetKeyBind("interact");

    }

    // Update is called once per frame
    void Update () {
		
	}
}
