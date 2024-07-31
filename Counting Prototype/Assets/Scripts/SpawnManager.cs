using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject dropPrefab;

    public float spawnRange = 19;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(dropPrefab, GenerateSpawnPosition(), dropPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 14, 0);

        return randomPos;
    }
}
