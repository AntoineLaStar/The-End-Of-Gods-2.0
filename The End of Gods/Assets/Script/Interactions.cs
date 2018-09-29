using UnityEngine;
using System.Collections;
public class Interactions : MonoBehaviour
{

    public Canvas messageCanvas;
    Canvas messageCanvasClone;

    void Start()
    {
        messageCanvasClone = Instantiate(messageCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            TurnOnMessage();
        }
    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
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