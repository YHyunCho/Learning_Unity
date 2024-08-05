using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameManager gameManager;

    public float speed;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward * horizontalInput * speed);
        //transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.UpdateScore();
        Destroy(other.gameObject);
    }
}
