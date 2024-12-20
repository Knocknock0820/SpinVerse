using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Map_Gyro : MonoBehaviour
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
        if(SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }

        if(Keyboard.current.rKey.wasPressedThisFrame){
                rotationChange = new Vector3(0,0,0);
        }
        
    }

    void FixedUpdate(){
        gyroChange();
        transform.position = player.GetComponent<Transform>().position;
        // Quaternion deviceRotation = DeviceRotation.Get();
        // transform.rotation = deviceRotation;
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x,q.z,q.y,-q.w);
    }

    void gyroChange(){
        if(Input.gyro.enabled)
        {
            
            rotationChange += gyro_sensity * new Vector3( 1 * Input.gyro.rotationRate.x, 1 * 0 * Input.gyro.rotationRate.z, 1 * Input.gyro.rotationRate.y);
            //Debug.Log(rotationChange);
            transform.eulerAngles = rotationChange;  
        }
    }
}
