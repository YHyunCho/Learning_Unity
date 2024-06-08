using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Vector3 position;
    public Color color;
    public float scale;
    public float rotationSpeed;

    void Start()
    {
        RandomVariable();

        transform.position = position;
        transform.localScale = Vector3.one * scale;

        InvokeRepeating("ChangeColor", 0, 5);
    }
    
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void ChangeColor()
    {
        Renderer.material.color = Random.ColorHSV();
    }

    void RandomVariable()
    {
        position = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        scale = Random.Range(1, 10);
        rotationSpeed = Random.Range(1, 10);
    }
}
