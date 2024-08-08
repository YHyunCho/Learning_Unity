using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    private float speed = 25;
    private bool isFishFresh;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManager.isGameActive)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);

            CheckOutOfBound();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive)
        {
            if (other.gameObject.CompareTag("Fresh"))
            {
                isFishFresh = true;
            }
            else
            {
                isFishFresh = false;
            }

            gameManager.UpdateScore(isFishFresh);
        }
        
        Destroy(other.gameObject);
    }

    private void CheckOutOfBound()
    {
        if (transform.position.z > gameManager.rightBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, gameManager.rightBound);
        }
        if (transform.position.z < gameManager.leftBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, gameManager.leftBound);
        }
    }
}
