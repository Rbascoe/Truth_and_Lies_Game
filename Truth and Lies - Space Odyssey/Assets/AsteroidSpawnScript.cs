using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnScript : MonoBehaviour
{

    public LogicScript logic;
    public GameObject asteroid;

    public float spawnRate = 15f;
    private float timer = 0;
    public bool startSpawn = false;
    // Start is called before the first frame update
    void Awake()
    {
        logic = GameObject.FindGameObjectWithTag("Timer").GetComponent<LogicScript>();


    }
    void Start()
    {
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
            if (startSpawn && (logic.gameTimer() > 0))
            {
                Debug.Log(logic.gameTimer());
                spawnAsteroid();
                timer = 0;
            }
            else if (logic.gameTimer() == 0)
            {
                Debug.Log(logic.gameTimer());
                startSpawn = false;
                timer = 0;
            }
        }

    }

    public void spawnAsteroid()
    {

        Instantiate(asteroid, transform.position, transform.rotation);

    }
}
