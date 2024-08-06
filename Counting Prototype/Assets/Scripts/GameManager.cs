using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text CounterText;
    public GameObject[] birds;
    public GameObject[] fishes;

    private Vector3[] birdPos = { new Vector3(13.3f, 22.62f, -13.49f), new Vector3(13.3f, 18.91f, 32.75f) };
    private Quaternion birdRotation;

    private int[] direction = { 0, 180 };
    private float birdSpawnInterval = 4;
    private int Count = 0;

    public float leftBound = -14.37f;
    public float rightBound = 27.63f;

    public bool isGameActive;


    private void Start()
    {
        isGameActive = true;
        Count = 0;

        StartCoroutine(SpawnRandomBirds());
        
    }

    //public void GameStart()
    //{
    //    isGameActive = true;
    //    Count = 0;

    //    StartCoroutine(SpawnRandomBirds());
    //    UpdateScore();
    //}

    IEnumerator SpawnRandomBirds()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(birdSpawnInterval);

            int birdIndex = Random.Range(0, birds.Length);
            int birdDir = Random.Range(0, direction.Length);

            birdRotation = Quaternion.Euler(0, direction[birdDir], 0);

            Instantiate(birds[birdIndex], birdPos[birdDir], birdRotation);
        }
    }

    public void UpdateScore(bool fresh)
    {
        if(fresh)
        {
            Count += 1;
        }
        else
        {
            Count -= 1;
        }
        CounterText.text = "Count : " + Count;
    }
}
