using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header("Setup")]
    private GameObject cam;
    private GameObject player;
    void Start()
    {
        cam = gameObject;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
