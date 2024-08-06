using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject dropPrefab;
    public GameObject[] birdPrefabs;

    private GameManager gameManager;

    private Vector3[] birdPos = { new Vector3(-2, 21.31f, -30.5f), new Vector3(3, 21.31f, 48.8f) };
    private Quaternion birdRotation;
    private int[] direction = { 0, 180 };
    
    private float startDelay = 2;
    private float spawnInterval = 5;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        InvokeRepeating("SpawnRandomBirds", startDelay, spawnInterval);
    }

    private void SpawnObject()
    {
        Instantiate(dropPrefab, GenerateSpawnPosition(), dropPrefab.transform.rotation);
    }

    private void SpawnRandomBirds()
    {
        int birdIndex = Random.Range(0, birdPrefabs.Length);
        int birdDir = Random.Range(0, direction.Length);

        birdRotation = Quaternion.Euler(0, direction[birdDir], 0);

        Instantiate(birdPrefabs[birdIndex], birdPos[birdDir], birdRotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosZ = Random.Range(gameManager.leftBound, gameManager.rightBound);

        Vector3 randomPos = new Vector3(13.3f, 16, spawnPosZ);

        return randomPos;
    }
}
