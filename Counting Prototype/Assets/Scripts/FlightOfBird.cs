using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightOfBird : MonoBehaviour
{
    public GameObject[] fishes;

    private Animator birdAni;
    private GameManager gameManager;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        birdAni = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        birdAni.SetBool("flying", true);
        StartCoroutine(SpawnRandomFishes());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > 55 || transform.position.z < -33)
        {
           Destroy(gameObject);
        }
    }

    IEnumerator SpawnRandomFishes()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(RandomSpawnInterval());

            if (transform.position.z > -9.3 && transform.position.z < 27.3)
            {
                int fishIndex = Random.Range(0, fishes.Length);

                Vector3 fishPos = new Vector3(13.3f, transform.position.y, transform.position.z);

                Instantiate(fishes[fishIndex], fishPos, fishes[fishIndex].transform.rotation);
            }
        }
    }

    private float RandomSpawnInterval()
    {
        return Random.Range(0.1f, 2);
    }
}
