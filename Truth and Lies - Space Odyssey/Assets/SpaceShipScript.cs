using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{

    //public Rigidbody2D spaceShipRigidBody;

    private GameObject shipBody;
    public LogicScript logic;
    public bool shipIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Timer").GetComponent<LogicScript>();

        shipBody = GameObject.Find("Spaceship");
    }

    // Update is called once per frame
    void Update()
    {
        // check to see if ship has not crashed
        if (shipIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveUp();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveDown();
            }
        }


    }

    public void moveUp()
    {

        // Moves an object up 2 units
        shipBody.transform.position += new Vector3(0, 2, 0);
    }

    public void moveDown()
    {

        // Moves an object down 2 units
        shipBody.transform.position += new Vector3(0, -2, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        logic.gameOver();
        shipIsAlive = false;


    }
}

