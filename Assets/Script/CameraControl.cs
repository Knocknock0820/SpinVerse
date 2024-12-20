using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Vector3 player_position;
    [SerializeField] private Vector3 deafult_Vector;
    // Start is called before the first frame update
    void Start()
    {
        player_position = player.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = player_position + deafult_Vector;
    }
}
