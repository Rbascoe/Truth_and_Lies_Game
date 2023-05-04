using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnScript : MonoBehaviour
{

    public LogicScript gameTimer;
    public GameObject asteroid;

    public float spawnRate = 15f;
    private float timer = 0;

    public bool startSpawn;
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<LogicScript>();
        startSpawn = true;
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
            // stopSpawn = false;
        }


        // if (timer < spawnRate)
        // {
        //     timer += Time.deltaTime;
        // }
        // else
        // {
        //     spawnAsteroid();
        //     timer = 0;

        // }


    }

    void spawnAsteroid()
    {
        if (startSpawn)
        {
            Debug.Log(gameTimer.gameTimer());
            if (gameTimer.gameTimer() != "0")
            {
                Instantiate(asteroid, transform.position, transform.rotation);
            }
            else
            {
                startSpawn = false;
                Debug.Log("Spawn Stopped");
            }
        }
    }
}
