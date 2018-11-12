using UnityEngine;
using System;
using System.Collections;

public class Mouvement : MonoBehaviour {
    [SerializeField] public float speed = 1f;
    [SerializeField] public float minDistance = 5f;
    GameObject player;
    Transform target;
    float range;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}
