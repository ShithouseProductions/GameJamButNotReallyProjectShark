using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement")]
    public float Velocity;
    private float velX;
    private float velY;

    private float scaleX = 1;
    private float scaleY = 1;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = Input.GetAxisRaw("Vertical");


        if (velY > 0)
        {
            scaleY = 1;
        } else if (velY < 0){
            scaleY = -1;
        }

        if (velX > 0)
        {
            scaleX = -1;
        } else if (velX < 0){
            scaleX = 1;
        } else if (velY != 0){
            scaleX = 0;
        }

        transform.localScale = new Vector2(1, scaleY);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, scaleX * 90 * scaleY);

        rb.velocity = new Vector2(velX * Velocity, velY * Velocity);
    }

    void Update()
    {
        
    }
}
