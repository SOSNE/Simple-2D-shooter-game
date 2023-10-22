using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject prefab1, prefab2;
    public static List<GameObject> enemyPool1, enemyPool2, helpPool;
    public int maxPool;
    public void Awake()
    {
        enemyPool1 = new List<GameObject>();
        enemyPool1 = new List<GameObject>();
        //helpPool = enemyPool1;
        CreateObjects(maxPool,prefab1,enemyPool1);
        CreateObjects(maxPool,prefab2,enemyPool2);
    }

    public void CreateObjects(int maxPoolCount, GameObject setPrefab, List<GameObject> objectsPool)
    {
        for (int i = 0; i < maxPoolCount; i++)
        {
            GameObject obj = Instantiate(setPrefab);
            obj.SetActive(false);
            objectsPool.Add(obj);
        }
    }

    public GameObject GetpollGameObject()
    {
        for (int i = 0; i < helpPool.Count; i++)
        {
            if (!helpPool[i].activeInHierarchy)
            {
                return helpPool[i];
            }
        }
        //CreateObjects(10);
        return null;
    }
}
