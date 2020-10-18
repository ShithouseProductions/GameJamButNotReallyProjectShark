using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement")]
    public float Velocity;
    [HideInInspector] public float actualVel;
    [HideInInspector] public float velX;
    [HideInInspector] public float velY;

    private float scaleX = 0;
    private float scaleY = 1;
    private float ScaleDual = 0;


    [Header("Tools")]
    [HideInInspector] public GameObject nearItem;


    [Header("GameObjects")]
    private Rigidbody2D rb;
    private GameObject manager;
    private GameObject attackRadius;

    void Start()
    {
        actualVel = Velocity;

        rb = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("Manager");
        attackRadius = transform.GetChild(0).gameObject;
    }


    void FixedUpdate()
    {
        if (!manager.GetComponent<GameController>().isPaused)
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
            if(velX != 0 || velY != 0)
            {
                GetComponent<Animator>().SetBool("isMoving", true);
            } else {
                GetComponent<Animator>().SetBool("isMoving", false);
            }


            transform.localScale = new Vector2(1, scaleY);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, scaleX * 90 * scaleY + ScaleDual);

            rb.velocity = new Vector2(velX * actualVel, velY * actualVel);

        } else {
            rb.velocity = new Vector2(0, 0);
            GetComponent<Animator>().SetBool("isMoving", false);
        }      
    }

    void Update()
    {
        if(!manager.GetComponent<GameController>().isPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                attackRadius.GetComponent<Attack>().DoAttack();
            }

            if (nearItem != null && Input.GetKeyDown(KeyCode.Space))
            {
                Item item = manager.GetComponent<ItemList>().GetItem(nearItem.GetComponent<ItemInfo>().type, nearItem.GetComponent<ItemInfo>().index);
                manager.GetComponent<Inventory>().Pickup(item);
                Destroy(nearItem);
                nearItem = null;
            }

            if(Input.GetKeyDown(KeyCode.H))
            {
                if(manager.GetComponent<Inventory>().extra[1].itemName != "" || manager.GetComponent<Inventory>().extra[2].itemName != "")
                {
                    if(manager.GetComponent<Inventory>().extra[1].itemName != "")
                    {
                        GetComponent<Health>().Heal(manager.GetComponent<Inventory>().extra[1].valueOne);
                        manager.GetComponent<Inventory>().Consume(1);
                    }
                }
            }

        }

    }


}
