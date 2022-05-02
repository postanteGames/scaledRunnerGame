using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool :MonoSingleton<ObjectPool>
{

    public GameObject yollar;
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public int poolSize;

    }
    [SerializeField] private Pool[] pools = null;

    private void Awake()
    {
        yollar = GameObject.Find("yollar");
        for (int j = 0; j <pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();

            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab,yollar.transform);
                obj.SetActive(false);
                pools[j].pooledObjects.Enqueue(obj);
            }
        }
    }
    public GameObject GetPooledObject (int objectType,Vector3 position)
    {
        if (objectType >= pools.Length)
        {
            return null;
        }
        GameObject obj = pools[objectType].pooledObjects.Dequeue();


        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 300);

        pools[objectType].pooledObjects.Enqueue(obj);
        
        obj.SetActive(true);
        return obj;
    }
    
}
