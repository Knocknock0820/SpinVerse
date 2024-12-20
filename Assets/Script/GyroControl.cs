using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    [SerializeField] private Vector3 rotationChange;
    [SerializeField] private float gyro_sensity;
    public GameObject player;

    void Start()
    {
        if(SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }else{
            Debug.Log("gyro not enabled, please retry");
        }
    }

    void Update()
    {
        if(SystemInfo.supportsGyroscope && Input.gyro.enabled == false)
        {
            Debug.Log("Reenabled gyroscope");
            Input.gyro.enabled = true;
        }
    }

    void FixedUpdate(){
        transform.position = player.GetComponent<Transform>().position;
        transform.rotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.z, Input.gyro.attitude.y, -Input.gyro.attitude.w);
    }
}
