using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPoolController : MonoBehaviour
{
    

    [SerializeField] private float _spawnInterval = 0.1f;
    [SerializeField] private Transform _spawnTransform;
    void Start()
    {
        StartCoroutine(nameof(SpawnRoutine));
    }
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var spawnedObject = ObjectPool.Instance.GetPooledObject(0, _spawnTransform.position);

                yield return new WaitForSeconds(_spawnInterval);
        }
    }

}
