using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameManager gameManager;
    private float sideBound = 18.7f;

    public float speed;

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

        CheckOutOfBound(sideBound);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.UpdateScore();
        Destroy(other.gameObject);
    }

    private void CheckOutOfBound(float bound)
    {
        if (transform.position.z > bound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bound);
        }
        if (transform.position.z < -bound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -bound);
        }
    }
}
