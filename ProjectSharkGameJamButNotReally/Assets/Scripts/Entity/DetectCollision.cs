using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{


    [Header("Tools")]
    private bool isPlayer;

    void Start()
    {
        if (this.gameObject == GameObject.Find("Player"))
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
                //col.getcomponent<stats>???
                transform.parent.GetComponent<Health>().Damage(col.transform.transform.parent.GetChild(0).GetComponent<Attack>().damage);
            }
        }

        if (!isPlayer)
        {
            if (col.transform.tag == "PlayerAttack")
            {
                //col.getcomponent<stats>
                transform.parent.GetComponent<Health>().Damage(col.transform.parent.GetChild(0).GetComponent<Attack>().damage);
            }
        }

    }
}
