using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField inputName;
    public Text bestScoreText;

    private void Start()
    {
        if (GameManager.Instance.bestUserName != null)
        {
            bestScoreText.text = $"BEST SCORE : {GameManager.Instance.bestUserName} : {GameManager.Instance.bestScore}";
        }
    }

    public void InputUserName()
    {
        GameManager.Instance.userName = inputName.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
