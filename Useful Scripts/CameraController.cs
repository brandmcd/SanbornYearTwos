using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject player; //player reference
    Vector3 offset; //distance between player and camera

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");

        //offset = palyer position - camera position
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //camera position = player position - offset
        transform.position = player.transform.position - offset;
    }
}
