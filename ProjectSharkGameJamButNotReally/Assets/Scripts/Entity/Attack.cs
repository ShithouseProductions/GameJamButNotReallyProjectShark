using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [Header("Setup")]
    public int damage;
    public float attackAnimDelay;


    [Header("Attack")]
    public bool attacked;
    public bool wait;
    private float attackTimer = 0.2f;
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
                curAttackDelay = attackDelay;
                attacked = false;
                transform.parent.GetComponent<Animator>().SetBool("isAttack", false);
                GetComponent<BoxCollider2D>().enabled = false;
                
                curAttackTimer = 0;
            }
        } 

        if(curAttackDelay > 0)
        {
            curAttackDelay -= Time.deltaTime;
            wait = false;
        }
    }


    public void DoAttack()
    {
        if(curAttackTimer <= 0 && curAttackDelay <= 0 && !wait)
        {
            wait = true;
            StartCoroutine(Attacker());
        }      
    }


    IEnumerator Attacker()
    {
        transform.parent.GetComponent<Animator>().SetBool("isAttack", true);
        yield return new WaitForSeconds(attackAnimDelay);
        GetComponent<BoxCollider2D>().enabled = true;
        attacked = true;
        curAttackTimer = attackTimer;
        yield return new WaitForSeconds(.1f);
        transform.parent.GetComponent<Animator>().SetBool("isAttack", false);
    }
}
