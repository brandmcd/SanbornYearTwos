using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    GameObject _player; //player reference
    Vector3 _offset; //distance between player and camera

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player");

        //offset = the difference in player position and camera position
        _offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //camera position = player position - offset
        transform.position = _player.transform.position - _offset;
    }
}
