using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    private GameObject PlayerPosition;
    Vector2 directionToPlayer;
    public float XpCurentValue;

    private void Awake()
    {
        PlayerPosition = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 playerPosition = PlayerPosition.transform.position;

        directionToPlayer = new Vector2(
            playerPosition.x - transform.position.x,
            playerPosition.y - transform.position.y
        );
        if (directionToPlayer.magnitude <= 5)
        {
            transform.up = directionToPlayer;
            GetComponent<Rigidbody2D>().velocity = new Vector2(directionToPlayer.x * 4, directionToPlayer.y * 4);
        }
        if (directionToPlayer.magnitude > 30)
        {
            gameObject.SetActive(false);
        }
        
    }

    void OnTriggerEnter2D(Collider2D CoTo)
    {
        if (CoTo.name == "Player")
        {
            ProgressBarLogick.curent += XpCurentValue;
            gameObject.SetActive(false);
        }
    }
}