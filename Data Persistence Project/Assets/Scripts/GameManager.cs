using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

        LoadNameAndScore();
    }

    public void UpdateBestScore(int currentScore)
    {
        if(currentScore >= bestScore)
        {
            bestScore = currentScore;
            bestUserName = userName;
        }

        SaveNameAndScore();
    }

    [System.Serializable]
    class SaveHighestScore
    {
        public int highestScore;
        public string userName;
    }

    public void SaveNameAndScore()
    {
        SaveHighestScore data = new SaveHighestScore();

        data.highestScore = bestScore;
        data.userName = bestUserName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveHighestScore data = JsonUtility.FromJson<SaveHighestScore>(json);

            bestUserName = data.userName;
            bestScore = data.highestScore;
        }
    }
}
