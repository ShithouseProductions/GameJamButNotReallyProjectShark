using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Velocity")]
    public float velocity;


    [Header("Tools")]
    private float deltaX;
    private float deltaY;

    [Header("GameObjects")]
    private GameObject player;
    private Rigidbody2D rb;
    private GameObject manager;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("Manager");
    }

    
    void Update()
    {
        if(!manager.GetComponent<GameController>().isPaused)
        {
            deltaX = player.transform.position.x - transform.position.x;
            deltaY = player.transform.position.y - transform.position.y;


            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime);

        }

        
    }
}
