using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectController : MonoBehaviour
{
    private GameManager gameManager;
    private int playerLives = 3;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if(gameObject.CompareTag("Fresh"))
            {
                gameManager.UpdatePlayerLives();
            }
            Destroy(gameObject);
        }
    }
}
