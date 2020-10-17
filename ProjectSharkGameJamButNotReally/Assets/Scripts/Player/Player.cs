using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement")]
    public float Velocity;
    [HideInInspector] public float velX;
    [HideInInspector] public float velY;

    private float scaleX = 0;
    private float scaleY = 1;
    private float ScaleDual = 0;

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

        if((velX > 0 && velY > 0) || (velX < 0 && velY < 0))
        {
            ScaleDual = 45;
        } else if ((velX > 0 && velY < 0) || (velX < 0 && velY > 0))
        {
            ScaleDual = -45;
        } else {
            ScaleDual = 0;
        }

        transform.localScale = new Vector2(1, scaleY);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, scaleX * 90 * scaleY + ScaleDual);

        rb.velocity = new Vector2(velX * Velocity, velY * Velocity);
    }

    void Update()
    {
        
    }
}
