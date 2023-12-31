 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
    [SerializeField]float mainThrust = 1500.0f;
    [SerializeField]float rotationThrust = 100.0f;

    Rigidbody myRigidbody;

    AudioSource rocketThrust;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        rocketThrust = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RocketMovement();
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
            print("ok");
            break;

            case "Finish":
            print("Success!");
            break;

            case "Fuel":
            print("Added Fuel");
            break;

            default:
            print("Dead!");
            break;


        }
    }

    private void RocketMovement()
    {
        float rotationSpeed = rotationThrust * Time.deltaTime;

        RocketThrusting();

        RocketRotation(rotationSpeed);
    }

    private void RocketThrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!rocketThrust.isPlaying)
            {
                rocketThrust.Play();
            }
        }
        else
        {
            rocketThrust.Stop();
        }
    }

    private void RocketRotation(float rotationSpeed)
    {
        myRigidbody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        myRigidbody.freezeRotation = false;
    }
}
