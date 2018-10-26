using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class Interactions : MonoBehaviour
{
    KeyCode keyPressed = KeyCode.None;
    public Canvas messageCanvas;
    Text keyText;


    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactAction();
        }
    }

    private void interactAction()
    {
        turnOnMessage();
        changeCanvasPosition();
        assignCanvasLetter();
    }

    private void turnOnMessage()
    {
        messageCanvas.enabled = true;
    }


    private void changeCanvasPosition()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            keyPressed = vKey;
            if (Input.GetKey(vKey))
            {
                Vector3 positionOfObject = gameObject.transform.position;
                float testHauteur = (gameObject.transform.lossyScale.y / 2) + 1;
                positionOfObject.y += testHauteur;
                messageCanvas.transform.position = positionOfObject;
            }
        }
    }

    private void assignCanvasLetter()
    {
        GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = KeyImputManager.GetKeyBind("interact");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            TurnOffMessage();
        }
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }
}