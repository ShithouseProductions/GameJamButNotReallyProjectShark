using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Velocity")]
    public float velocity;


    [Header("Tools")]
    public GameObject lootPrefab;
    private float deltaX;
    private float deltaY;

    [Header("GameObjects")]
    private GameObject player;
    private Rigidbody2D rb;
    private GameObject manager;
    private GameObject attackRadius;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("Manager");

        attackRadius = transform.GetChild(0).gameObject;
    }


    void Update()
    {
        if (!manager.GetComponent<GameController>().isPaused)
        {
            deltaX = player.transform.position.x - transform.position.x;
            deltaY = player.transform.position.y - transform.position.y;

            float sd = 1.5f;   //stopDistance

            if (deltaX > sd || deltaX < -sd || deltaY > sd || deltaY < -sd)
            {
                float maxDistance = 12;

                if (deltaX < maxDistance && deltaX > -maxDistance && deltaY < maxDistance && deltaY > -maxDistance)
                {
                    if (!attackRadius.GetComponent<Attack>().wait)
                    {
                        float angle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

                        GetComponent<Animator>().SetBool("isMoving", true);
                        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime);
                    }
                } else {
                    GetComponent<Animator>().SetBool("isMoving", false);
                }


            } else {
                GetComponent<Animator>().SetBool("isMoving", false);
                attackRadius.GetComponent<Attack>().DoAttack();
            }


        } else {
            GetComponent<Animator>().SetBool("isMoving", false);
        }


    }

    public void DropLoot()
    {

        int rand = Random.Range(0, 5);
        Item[] list = new Item[0];

        switch (rand)
        {
            case 0:
                list = manager.GetComponent<ItemList>().helmetList;
                break;
            case 1:
                list = manager.GetComponent<ItemList>().chestList;
                break;
            case 2:
                list = manager.GetComponent<ItemList>().legList;
                break;
            case 3:
                list = manager.GetComponent<ItemList>().weaponList;
                break;
            case 4:
                list = manager.GetComponent<ItemList>().potionList;
                break;
        }

        int item = Random.Range(0, list.Length);

        GameObject temp = Instantiate(lootPrefab, transform.position, Quaternion.identity);
        temp.GetComponent<ItemInfo>().type = list[item].type;
        temp.GetComponent<ItemInfo>().index = item;
        temp.GetComponent<SpriteRenderer>().sprite = list[item].sprite;

    }
}
