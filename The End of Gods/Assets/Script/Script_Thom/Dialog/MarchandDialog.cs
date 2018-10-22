using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchandDialog : MonoBehaviour {
    [SerializeField] Canvas marchandDialog;
    [SerializeField] Canvas shop;
    bool DialogIsShowen;
    bool shopIsOpen;
    bool wait;

    private void Start()
    {
        DialogIsShowen = false ;
        wait = false;
    }
    private void Update()
    {
        if (DialogIsShowen)
        {
            checkMarchandDialog();
        }
        
    }
    private void checkMarchandDialog()
    {
            foreach (KeyCode keyPress in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyUp(keyPress))
                {
                    KeyCode keyPressed = keyPress;
                    if (keyPressed.ToString() == KeyImputManager.GetKeyBind("interact"))
                    {
                        if (wait)
                        {
                            wait = false;
                        }
                        else
                        {
                            openShop();
                        }

                    }
                }
            }
        }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!DialogIsShowen)
        {
            if (collision.tag == "Player")
            {
                foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyUp(vKey))
                    {
                        KeyCode keyPressed = vKey;
                        if (keyPressed.ToString() == KeyImputManager.GetKeyBind("interact"))
                        {
                            ShowDialog();
                            wait = true;
                        }
                    }
                }
            }
       
        }

    }
    private void openShop()
    {
        shop.enabled = true;
        marchandDialog.enabled = false;
        DialogIsShowen = false;
    }

    private void ShowDialog()
    {
        marchandDialog.enabled =true;
        DialogIsShowen = true;
        KeyImputManager.changeLockState();
    }
}

