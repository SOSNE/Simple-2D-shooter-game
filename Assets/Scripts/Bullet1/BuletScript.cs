using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuletScript : MonoBehaviour
{
    private float  shortestDistance = 1000, time,destroyTime;
    public float  dirx, diry, BuletSpeed;
    public static float BuletDemage = 10, BulletWidthStatic = 0.08f, homingPower = 0.1f, homingTime = 0.5f;
    private Transform PlayerPosition;
    public static Vector2 directionBuletScript, BuletVector;
    public float BulletRotation;
    private GameObject nearestEnemy;
    private Vector2 pathCorrectionVector2, velocity;
    public static bool homingOn = false;

    private void OnDisable()
    {
        time = 0;
        BuletDemage = 10;
        homingTime = 1;
    }

    void OnEnable()
    {
        PlayerPosition = GameObject.Find("Player").transform;
        //changing bullet width
        gameObject.GetComponent<Transform>().localScale = new Vector3(BulletWidthStatic, 1, 1);
        dirx = PlayerRotation.directionPlayerRotation.x;
        diry = PlayerRotation.directionPlayerRotation.y;
        directionBuletScript = new Vector2(dirx, diry).normalized; // ta normalizacja zamienia wektor na długość ale z zachowaniem jego kierunku
        velocity = directionBuletScript;
    }

    
    void Update()
    {
        
        
        transform.up = PathCorrection(velocity);

        Vector2 LenghtFromPlayer = new Vector2(PlayerPosition.position.x - transform.position.x,
             PlayerPosition.position.y - transform.position.y);
        destroyTime += Time.deltaTime;
        if (destroyTime >= 5|| LenghtFromPlayer.magnitude >50)
        {
            gameObject.SetActive(false);
            destroyTime = 0;
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity =  PathCorrection(velocity) * BuletSpeed;
    }

    //homing logic
    Vector2 PathCorrection(Vector2 velocityVector)
    {
        GameObject player = GameObject.Find("Player");
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            if (Vector2.Distance(enemy.transform.position, player.transform.position) < shortestDistance || nearestEnemy == null)
            {
                shortestDistance = Vector2.Distance(player.transform.position, enemy.transform.position);
                nearestEnemy = enemy;
            }
        }
        time += Time.deltaTime;
        if (nearestEnemy == null)
        {
            time = 0;
        }
        if (time > homingTime && homingOn)
        {
            pathCorrectionVector2 = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, nearestEnemy.transform.position - gameObject.transform.position,homingPower).normalized;
        }
        else if (time < homingTime|| homingOn ==false)
        {
            pathCorrectionVector2 = Quaternion.Euler(0, 0, BulletRotation)*velocityVector;
        }
        return pathCorrectionVector2;
    }
}