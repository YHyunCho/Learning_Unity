using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string userName;
    public string bestUserName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateBestScore(int currentScore)
    {
        if(currentScore >= bestScore)
        {
            bestScore = currentScore;
            bestUserName = userName;
        }
    }
}
