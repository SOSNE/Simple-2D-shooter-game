using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnig : MonoBehaviour
{
    private float i, time, xPoz, yPoz, Time2, EnemyXp, HpValue, DamageValue, help, enemyPlayerDistance = 20;
    private int EnemyArrNum;
    public GameObject[] Enemy1;
    private GameObject gameManager;
    public Transform PlayerPosition;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    int RandomTwo()
    {
        return Random.Range(1, 3);
    }

    public void playerProperties(float Time2)
    {
        float a = Random.Range(0, Time2);
        a = Mathf.Clamp(a, 0, 150);
        switch (a)
        {
            case < 30:
            {
                EnemyArrNum = 0;
                EnemyXp = Random.Range(5, 10);
                HpValue = 20;
                DamageValue = 1;
            }
                break;
            case < 150:
            {
                EnemyArrNum = 1;
                EnemyXp = Random.Range(10, 20);
                HpValue = 30;
                DamageValue = 2;
            }
                break;
        }

        switch (RandomTwo())
        {
            case 1:
            {
                xPoz = Random.Range(-25f, 25f);
                if (RandomTwo() == 1)
                {
                    yPoz = 21;
                }
                else if (RandomTwo() == 2)
                {
                    yPoz = -21;
                }
            }
                break;
            case 2:
            {
                yPoz = Random.Range(-21f, 21f);
                if (RandomTwo() == 1)
                {
                    xPoz = -25;
                }
                else if (RandomTwo() == 2)
                {
                    xPoz = 25;
                }
            }
                break;
        }
    }

    void Update()
    {
        Time2 += Time.deltaTime * 0.5f;
        time += Time.deltaTime;
        if (gameManager.GetComponent<TimeCounter>().timeHandler(0.1f))
        {
            playerProperties(Time2);
            Vector2 position = new Vector2(PlayerPosition.position.x + xPoz, PlayerPosition.position.y + yPoz);
            enemyPlayerDistance = Vector2.Distance(PlayerPosition.position, position);
            while (enemyPlayerDistance < 16)
            {
                playerProperties(Time2);
                position = new Vector2(PlayerPosition.position.x + xPoz, PlayerPosition.position.y + yPoz);
                enemyPlayerDistance = Vector2.Distance(PlayerPosition.position, position);
            }

            GameObject NewEnemy = Instantiate(Enemy1[EnemyArrNum], position, quaternion.identity);
            NewEnemy.GetComponent<EnemyStats>().XpAmount = EnemyXp;
            NewEnemy.GetComponent<EnemyStats>().HpValueCur = HpValue;
            NewEnemy.GetComponent<EnemyStats>().DmPower = DamageValue;
            time = 0;
        }
    }
}