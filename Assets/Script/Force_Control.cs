using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Force_Control : MonoBehaviour
{
    public GameObject player;
    private Transform playerTransform;
    [SerializeField] private float distance_to_player;
    private Rigidbody playerRigidBody;
    private Vector3 pullForce;
    [SerializeField] private float intensity;
    public GameObject center;

    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        playerRigidBody = player.GetComponent<Rigidbody>();
        transform.position = playerTransform.position + new Vector3(0, -distance_to_player, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        if(Keyboard.current.rKey.wasPressedThisFrame){
            Debug.Log("pressing r");
            ResetForcePosition();
        }
        //Debug.Log(transform.position);
        pullForce = ( transform.position - playerTransform.position) * intensity;
        playerRigidBody.AddForce(pullForce);

        
    }

    void FixedUpdate(){
        
    }

    void ResetForcePosition(){
        center.GetComponent<Transform>().rotation = Quaternion.identity;
        transform.position = playerTransform.position + new Vector3(0, -distance_to_player, 0);
    }
}
