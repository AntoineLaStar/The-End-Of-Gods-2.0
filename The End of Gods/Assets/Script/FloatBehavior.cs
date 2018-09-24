using UnityEngine;
using System;
using System.Collections;

public class FloatBehavior : MonoBehaviour
{
    float originalY;

    public float direction = 1;
    public float floatStrength = 0.2f;
    public float floatSpeed = 2;

    void Start()
    {
        this.originalY = this.transform.position.y ;
    }

    void Update()
    {

            transform.position = new Vector3(transform.position.x, originalY + ((float)Math.Sin(Time.time * floatSpeed) * floatStrength * direction),
                transform.position.z);
    }
}