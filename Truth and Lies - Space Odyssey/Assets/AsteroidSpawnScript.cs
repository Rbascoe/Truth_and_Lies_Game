using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnScript : MonoBehaviour
{
    public GameObject asteroid;

    public float spawnRate = 15f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnAsteroid();
            timer = 0;
        }
    }

    void spawnAsteroid()
    {

        Instantiate(asteroid, transform.position, transform.rotation);
    
    }
}
