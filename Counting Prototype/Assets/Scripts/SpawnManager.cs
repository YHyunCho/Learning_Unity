using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject dropPrefab;

    public float spawnRange = 19;
    private float startDelay = 3;
    private float spawnInterval = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, spawnInterval);
    }

    private void SpawnObject()
    {
        Instantiate(dropPrefab, GenerateSpawnPosition(), dropPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(0, 14, spawnPosZ);

        return randomPos;
    }
}
