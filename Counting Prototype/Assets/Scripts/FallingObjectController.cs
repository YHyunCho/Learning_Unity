using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectController : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
