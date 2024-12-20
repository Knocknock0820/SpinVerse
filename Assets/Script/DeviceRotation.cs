using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class DeviceRotation
{
    public static bool gyroInitialized = false;

    public static bool HasGyroscope{
        get{
            return SystemInfo.supportsGyroscope;
        }
    }

    public static Quaternion Get(){
        if(!gyroInitialized){
            InitGyro();
        }
        return HasGyroscope
            ? ReadyGyroscopeRotation()
            : Quaternion.identity;
    }

    private static void InitGyro(){
        if(HasGyroscope){
            Input.gyro.enabled = true;
            Input.gyro.updateInterval = 0.0167f;
        }
        gyroInitialized = true;
    }


    private static Quaternion ReadyGyroscopeRotation(){
        return new Quaternion(1,1,1,1) * new Quaternion(Input.gyro.attitude.x,Input.gyro.attitude.z,Input.gyro.attitude.y,-Input.gyro.attitude.w);
    }

}
