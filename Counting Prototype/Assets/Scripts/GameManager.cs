using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI gameOverText;
    public GameObject heart;
    public GameObject mainLight;
    public Camera mainCamera;
    public Button gameStartButton;
    public Button howToPlayButton;

    public GameObject[] birds;
    public GameObject[] fishes;
    public GameObject[] hearts;

    private Vector3[] birdPos = { new Vector3(13.3f, 22.62f, -13.49f), new Vector3(13.3f, 18.91f, 32.75f) };
    private Vector3 cameraPos = new Vector3(33.9f, 22.6f, 8.7f);
    private Vector3 cameraRotation = new Vector3(15, 270, -0.076f);
    private Quaternion lightRotation = Quaternion.Euler(161.32f, 150, 0);
    private Quaternion birdRotation;

    private int[] direction = { 0, 180 };
    private float birdSpawnInterval = 4;
    private int Count = 0;
    private int playerLives = 3;

    public float cameraRotateSpeed;
    public float cameraMoveSpeed;

    public float leftBound = -14.37f;
    public float rightBound = 27.63f;

    public bool isGameActive;

    public void GameStart()
    {
        isGameActive = true;
        Count = 0;
        playerLives = 3;

        gameStartButton.gameObject.SetActive(false);
        howToPlayButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        CounterText.gameObject.SetActive(true);
        heart.gameObject.SetActive(true);

        mainCamera.transform.DOMove(cameraPos, cameraMoveSpeed);
        mainCamera.transform.DORotate(cameraRotation, cameraRotateSpeed);

        mainLight.transform.rotation = lightRotation;

        StartCoroutine(SpawnRandomBirds());
    }

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

    public void UpdatePlayerLives()
    {
        playerLives -= 1;

        if (playerLives == 0)
        {
            GameOver();
        }
    }

    public void CheckPlayerLives()
    {
        Destroy(hearts[playerLives - 1].gameObject);
        playerLives -= 1;

        if (playerLives == 0)
        {
            isGameActive = false;
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
    }
}
