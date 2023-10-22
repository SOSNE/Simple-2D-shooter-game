using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;


public class BuletSpawning : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject CreatedBullet;
    private GameObject gameManager;
    public static float time, fierRateStatic = 0.2f;
    public static int bulletMultiplierStatic = 1;
    public Transform playerPosition;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        float startRotation = -(bulletMultiplierStatic - 1) * 7.5f;

        time += Time.deltaTime; 
        if (Input.GetMouseButton(0))
        {
            if (gameObject.GetComponent<TimeCounter>().timeHandler(fierRateStatic))
            {
                for (int i = 0; i < bulletMultiplierStatic ; i++)
                {
                    CreatedBullet = gameObject.GetComponent<ObjectPool>().GetpollGameObject();
                    if (CreatedBullet == null)
                    {
                        return;
                    }
                    CreatedBullet.transform.position = transform.position;
                    CreatedBullet.GetComponent<BuletScript>().BulletRotation = 0;
                    CreatedBullet.GetComponent<BuletScript>().BulletRotation += startRotation+(15 * i);
                    CreatedBullet.SetActive(true);
                }
            }
        }
    }
}
