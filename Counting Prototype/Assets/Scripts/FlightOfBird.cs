using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightOfBird : MonoBehaviour
{
    private Animator birdAni;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        birdAni = GetComponent<Animator>();

        birdAni.SetBool("flying", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
