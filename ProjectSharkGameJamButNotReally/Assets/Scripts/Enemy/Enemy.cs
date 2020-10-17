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
<<<<<<< HEAD
        if(manager.GetComponent<GameController>().isPaused)
=======
        if(!manager.GetComponent<GameController>().isPaused)
>>>>>>> main
        {
            deltaX = player.transform.position.x - transform.position.x;
            deltaY = player.transform.position.y - transform.position.y;

            //transform.Translate(Vector2.MoveTowards(transform.position, player.transform.position, 3) * velocity * Time.deltaTime);

<<<<<<< HEAD
            Vector3 dir = player.transform.position - transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            rb.rotation = angle;
            dir.Normalize();

            rb.MovePosition(transform.position + (dir * velocity * Time.deltaTime));
=======
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime);

          /*  Vector3 dir = player.transform.position - transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            rb.rotation = angle;
            dir.Normalize();

            rb.MovePosition(transform.position + (dir * velocity * Time.deltaTime));*/
>>>>>>> main
        }

        
    }
}
