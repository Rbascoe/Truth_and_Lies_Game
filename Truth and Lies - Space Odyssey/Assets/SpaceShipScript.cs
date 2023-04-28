using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{

    //public Rigidbody2D spaceShipRigidBody;

    private GameObject shipBody;
    public float moveShip = 5;
    // Start is called before the first frame update
    void Start()
    {
        shipBody = GameObject.Find("Spaceship");
    }

    // Update is called once per frame
    void Update()
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

    public void moveUp()
    {

        // Moves an object up 2 units
        shipBody.transform.position += new Vector3(0, 2, 0);
    }

    public void moveDown()
    {

        // Moves an object up 2 units
        shipBody.transform.position += new Vector3(0, -2, 0);
    }
}
