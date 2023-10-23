using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EemyMovment : MonoBehaviour
{
    private Transform PlayerPosition;
    public Vector2 directionToPlayer;
    public float speed;
    
    private void Awake()
    {
        PlayerPosition = GameObject.Find("Player").transform;
    }
    void Update()
    {
        Vector3 playerPosition = PlayerPosition.position;
        
        directionToPlayer = new Vector2(
            playerPosition.x - transform.position.x,
            playerPosition.y - transform.position.y
        ).normalized;
        
        transform.up = directionToPlayer;
        
        
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = directionToPlayer * speed;
    }
}
