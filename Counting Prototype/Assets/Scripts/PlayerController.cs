using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameManager gameManager;

    public float speed;
    private bool isFishFresh;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //playerRb.AddForce(Vector3.forward * horizontalInput * speed, ForceMode.Impulse);
        transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);

        CheckOutOfBound();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fresh"))
        {
            isFishFresh = true;
        } else
        {
            isFishFresh = false;
        }

        gameManager.UpdateScore(isFishFresh);

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
