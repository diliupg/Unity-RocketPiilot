using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
    float mainThrust = 2.0f;
    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RocketMovement();
    }

    private void RocketMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * mainThrust);
        }

        if (Input.GetKey(KeyCode.A))
        {
            print("Turn Left");
        }

        if (Input.GetKey(KeyCode.D))
        {
            print("Turn Right");
        }
    }
}
