using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    
    public GameObject XpPrefab, gameManager;
    private GameObject Bulet;
    private float timeOpacity;
    private bool Hit = false;
    private Vector2 VecotrBuletToEnemy;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void OnTriggerEnter2D(Collider2D CoTo)
    {
        if (CoTo.name == "Bullet(Clone)")
        {
            Bulet = CoTo.gameObject;
            
            VecotrBuletToEnemy = new Vector2
            (Bulet.transform.position.x - gameObject.transform.position.x,
                Bulet.transform.position.y - gameObject.transform.position.y).normalized;
            
            CoTo.gameObject.SetActive(false);
            Hit = true;
           gameObject.GetComponent<EnemyStats>().HpValueCur -= BuletScript.BuletDemage;
        }
    }
    void Update()
    {
        if (Hit)
        {
            timeOpacity += Time.deltaTime;
            if (timeOpacity <=0.1)
            {
                Color currentColor = gameObject.GetComponent<Renderer>().material.color;
                currentColor.a = 114f / 255f;
                gameObject.GetComponent<Renderer>().material.color = currentColor;
                gameObject.GetComponent<Rigidbody2D>().velocity = BuletScript.directionBuletScript*3;
            }
            else
            {
                Color currentColor = gameObject.GetComponent<Renderer>().material.color;
                currentColor.a = 1;
                gameObject.GetComponent<Renderer>().material.color = currentColor; 
                Hit = false;
                timeOpacity =0;
            }
        }
        
        if (gameObject.GetComponent<EnemyStats>().HpValueCur <= 0)
        {
            GameObject XpObject = gameManager.GetComponent<ObjectPool>().GetpollGameObject();
            if (XpObject == null)
            {
                return;
            }
            XpObject.transform.position = transform.position;
            XpObject.SetActive(true);
            XpObject.GetComponent<Xp>().XpCurentValue = gameObject.GetComponent<EnemyStats>().XpAmount;
            Destroy(gameObject);
        }
    }
}
