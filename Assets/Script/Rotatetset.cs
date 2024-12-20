using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatetset : MonoBehaviour
{
    public Vector3 pivotPoint;
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 1f;

    private Vector3 pivotOffset;

    void Start()
    {
        // Calculate the offset vector from the object's center to the pivot point
        pivotOffset = pivotPoint - transform.position;
    }

    void Update()
    {
        
        
    }

    public void rotatethecube(){
        Debug.Log("press");
            // Rotate the object around its center
            transform.RotateAround(transform.position, rotationAxis, rotationSpeed * Time.deltaTime);

            // Translate the object's position to maintain the pivot point's position
            transform.position += transform.rotation * pivotOffset - pivotOffset;
    }
}
