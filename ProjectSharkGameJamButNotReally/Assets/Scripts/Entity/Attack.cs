using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [Header("Setup")]
    public int damage;


    [Header("Attack")]
    public bool attacked;
    private float attackTimer = 0.5f;
    private float attackDelay = 1f;

    public float curAttackTimer = 0;
    public float curAttackDelay = 0;


    void Start()
    {
        //damage = Player.armor
        //setup range if stats affects it.
    }

    
    void Update()
    {
        if(attacked)
        {
            curAttackTimer -= Time.deltaTime;
            if(curAttackTimer <= 0)
            {
                attacked = false;
                transform.parent.GetComponent<Animator>().SetBool("isAttack", false);
                GetComponent<BoxCollider2D>().enabled = false;
                curAttackDelay = attackDelay;
                curAttackTimer = 0;
            }
        } 

        if(curAttackDelay > 0)
        {
            curAttackDelay -= Time.deltaTime;
        }
    }


    public void DoAttack()
    {
        if(curAttackTimer <= 0 && curAttackDelay <= 0)
        {
            transform.parent.GetComponent<Animator>().SetBool("isAttack", true);
            GetComponent<BoxCollider2D>().enabled = true;
            attacked = true;
            curAttackTimer = attackTimer;
        }      
    }
}
