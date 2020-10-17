using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Setup")]
    public int maxHealth;

    [Header("Tools")]
    public int curHealth;
    private int armor;
    

    void Start()
    {
        curHealth = maxHealth;
        //armor = GetComponent<Armor>().armor;
    }

    
    void Update()
    {
        
    }


    public void Damage(int dmg)
    {
        // use armor to calculate blocked dmg
        curHealth -= dmg;

        if(curHealth <= 0)
        {
            curHealth = 0;
            // Lose
        } else {
            // Update health UI
        }
    }
}
