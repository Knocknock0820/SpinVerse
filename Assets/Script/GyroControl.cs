using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Quaternion initialRotation; // To store the initial gyroscope rotation
    public GameObject player;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            initialRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.z, Input.gyro.attitude.y, Input.gyro.attitude.w);
        }
        else
        {
            Debug.Log("Gyroscope not supported, please retry on a compatible device.");
        }
    }

    void Update()
    {
        if(Keyboard.current.kKey.wasPressedThisFrame){
            initialRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.z, Input.gyro.attitude.y, Input.gyro.attitude.w);
            Debug.Log("Reset gyroscope.");
        }

        if (SystemInfo.supportsGyroscope && !Input.gyro.enabled)
        {
            initialRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.z, Input.gyro.attitude.y, Input.gyro.attitude.w);
            Debug.Log("Re-enabled gyroscope.");
            Input.gyro.enabled = true;
        }
    }

    void FixedUpdate()
    {
        // Synchronize the object with the player's position
        transform.position = player.transform.position;

        // Adjust rotation based on the initial calibration
        Quaternion currentRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.z, Input.gyro.attitude.y, Input.gyro.attitude.w);
        Quaternion adjustedRotation = Quaternion.Inverse(initialRotation) * currentRotation;

        // Apply the adjusted rotation directly
        transform.rotation = adjustedRotation;
    }
}
