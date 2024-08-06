using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text CounterText;

    public float leftBound = -14.37f;
    public float rightBound = 27.63f;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    public void UpdateScore()
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
    }
}
