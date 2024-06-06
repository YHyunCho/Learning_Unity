using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerX : MonoBehaviour
{
    private float speed;
    private float rotationSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}