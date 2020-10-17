using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{


    [Header("Tools")]
    public bool isPlayer;

    void Start()
    {
        if (transform.parent.gameObject == GameObject.Find("Player"))
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
    }


    private void OnTriggerStay2D(Collider2D col)
    {

        if (isPlayer)
        {
            if (col.tag == "EnemyAttack")
            {
                transform.parent.GetComponent<Health>().Damage(col.transform.parent.GetChild(0).GetComponent<Attack>().damage);
            }
        }

        if (!isPlayer)
        {
            if (col.transform.tag == "PlayerAttack")
            {
                transform.parent.GetComponent<Health>().Damage(col.transform.parent.GetChild(0).GetComponent<Attack>().damage);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(isPlayer)
        {
            if(col.tag == "Enemy")
            {
                transform.parent.GetComponent<Health>().Damage(col.transform.GetChild(0).GetComponent<Attack>().damage);
            }

            if(col.tag == "Item")
            {
                transform.parent.GetComponent<Player>().nearItem = col.gameObject;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if(isPlayer)
        {
            if(col.tag == "Item")
            {
                transform.parent.GetComponent<Player>().nearItem = null;
            }
        }
    }
}
