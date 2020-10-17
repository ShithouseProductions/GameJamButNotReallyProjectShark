using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Tools")]
    private float deltaX;
    private float deltaY;

    [Header("GameObjects")]
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    
    void Update()
    {
        deltaX = player.transform.position.x - transform.position.x;
        deltaY = player.transform.position.y - transform.position.y;

        
    }
}
