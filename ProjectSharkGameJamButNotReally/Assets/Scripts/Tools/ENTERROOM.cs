using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENTERROOM : MonoBehaviour
{
    [Header("SPAWN")]
    public GameObject doorlocked;
    private bool completed = false;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Instantiate(doorlocked, transform.position, Quaternion.identity);
        }
    }


}
