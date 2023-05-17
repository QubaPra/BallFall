using System;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    public GameObject ball;
    private Vector3 initialGravity;

    void Start()
    {       
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

            Debug.Log("xRotation: " + xRotation);
            Debug.Log("yRotation: " + yRotation);
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