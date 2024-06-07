using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float sendCooldown = 3f;
    private bool canPress = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canPress)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canPress = false;

            Invoke("ResetPress", sendCooldown);
        }
    }

    void ResetPress()
    {
        canPress = true;
    }
}
