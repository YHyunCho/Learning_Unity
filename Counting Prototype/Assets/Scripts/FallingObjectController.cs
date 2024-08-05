using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectController : MonoBehaviour
{

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
