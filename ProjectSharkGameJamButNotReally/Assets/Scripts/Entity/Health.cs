using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Setup")]
    public int maxHealth;

    [Header("Tools")]
    public int curHealth;
    private int armor;
    private float cooldown;
    private bool isPlayer;


    [Header("GameObjects")]
    private GameObject healthbar;


    void Start()
    {
        curHealth = maxHealth;

        if (this.gameObject == GameObject.Find("Player"))
        {
            isPlayer = true;
        } else {
            isPlayer = false;
        }

        if(isPlayer)
        {
            healthbar = GameObject.Find("HealthbarParent");
        } else {
            healthbar = transform.GetChild(2).gameObject;
        }

        //armor = GetComponent<Armor>().armor;
    }

    
    void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }



    public void Damage(int dmg)
    {
        if(cooldown <= 0)
        {
            cooldown = 0.75f;
            print("Health.cs: health lost");
            // use armor to calculate blocked dmg
            curHealth -= dmg;
            StartCoroutine(Flash());

            if(curHealth <= 0)
            {
                curHealth = 0;
                Destroy(gameObject);
            }

            UpdateUI();
        }
    }


    public void Heal(int hp)
    {
        curHealth += hp;

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        UpdateUI();
    }


    private void SetupUI()
    {

    }


    private void UpdateUI()
    {
        if(isPlayer)
        {
            // update hearts
        }

        if(!isPlayer)
        {
            float perc = (float)curHealth / maxHealth;

            GameObject redbar = healthbar.transform.GetChild(0).gameObject;

            redbar.transform.localScale = new Vector2(perc, 1);
            redbar.transform.localPosition = new Vector2((1-perc) * -0.08f, 0);
        }
    }


    IEnumerator Flash()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.15f);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
