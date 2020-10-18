using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENTERROOM : MonoBehaviour
{

    [Header("SPAWN")]
    public GameObject doorlocked;
    private bool completed = false;
    private bool active;


    [Header("enemy")]
    public GameObject[] enemy = new GameObject[0];
    private GameObject temp;


    void Start()
    {

    }

    private void Update()
    {
        if(active)
        {
            if(transform.childCount == 0)
            {
                Destroy(temp);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            active = true;
            temp = Instantiate(doorlocked, transform.position, Quaternion.identity);
            SpawnEnemy();
        }
    }


    private void SpawnEnemy()
    {
        int rand = Random.Range(0, 6);

        for(int i = 0; i < rand; i++)
        {
            int posX = Random.Range(2, 20);
            int posY = Random.Range(2, 10);

            int enem = Random.Range(0, enemy.Length);

            Instantiate(enemy[enem], transform.position + new Vector3(posX, posY, 0), Quaternion.identity, transform);
        }
    }


}
