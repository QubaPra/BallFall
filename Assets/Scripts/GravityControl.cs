using System;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    private Vector3 initialGravity;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        initialGravity = Physics.gravity;
    }

    void Update()
    {
        float xRotation = 0f;
        float yRotation = 0f;

        // Check if gyro is available
        if (SystemInfo.supportsGyroscope)
        {
            xRotation = Input.acceleration.x;
            yRotation = Input.acceleration.y;
        }
        else
        {
            // Use arrow keys to control gravity direction
            xRotation = Input.GetAxis("Horizontal");
        }

        Vector3 gravityDirection = new Vector3(xRotation * 5f, yRotation * 5f, 0f);
        Physics.gravity = initialGravity + gravityDirection;
    }
}
