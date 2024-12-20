using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector3 origin_position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixUpdate(){

    }
    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.hKey.wasPressedThisFrame){
                transform.position = origin_position;
        }
    }
}
