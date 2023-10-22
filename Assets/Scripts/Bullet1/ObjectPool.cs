using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
        public GameObject prefab;
        public List<GameObject> objectsPool;
        public int maxPool;
        public void Awake()
        {
                objectsPool = new List<GameObject>();
                CreateObjects(maxPool);
        }

        public void CreateObjects(int maxPoolCount)
        {
                for (int i = 0; i < maxPoolCount; i++)
                {
                        GameObject obj = Instantiate(prefab);
                        obj.SetActive(false);
                        objectsPool.Add(obj);
                }
        }

        public GameObject GetpollGameObject()
        {
                for (int i = 0; i < objectsPool.Count; i++)
                {
                        if (!objectsPool[i].activeInHierarchy)
                        {
                                return objectsPool[i];
                        }
                }
                CreateObjects(40);
                return null;
        }
}
