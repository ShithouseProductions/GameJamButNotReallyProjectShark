using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement")]
    public float Velocity;
    private float velX;
    private float velY;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = Input.GetAxisRaw("Vertical");
        print(velX);

        rb.velocity = new Vector2(velX * Velocity, velY * Velocity);
    }

    void Update()
    {
        
    }
}
