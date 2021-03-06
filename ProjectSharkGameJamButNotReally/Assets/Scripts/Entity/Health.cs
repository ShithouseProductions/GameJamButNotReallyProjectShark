﻿using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Setup")]
    public int defaultHealth;
    private int armorHealth;
    private int maxHealth;


    [Header("Tools")]
    public int curHealth;
    private int armor;
    private float cooldown;
    private bool isPlayer;


    [Header("GameObjects")]
    public GameObject heartPrefab;
    public Sprite[] heartSprite;
    private GameObject healthbar;
    private GameObject[] heartList;


    void Start()
    {
        maxHealth = defaultHealth;
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
            GetComponent<Armor>().UpdateArmor();

        } else {
            healthbar = transform.GetChild(2).gameObject;
        }

        
    }

    
    void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }


    public void UpdateArmor(int armor)
    {
        armorHealth = armor;

        maxHealth = defaultHealth + armorHealth;

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        CreateUI();

    }

    public void Damage(int dmg)
    {
        if(cooldown <= 0)
        {
            cooldown = 0.75f;
            curHealth -= dmg;
            StartCoroutine(Flash());

            if(curHealth <= 0)
            {
                curHealth = 0;
                if(!isPlayer)
                {
                    GetComponent<Enemy>().DropLoot();
                    Destroy(gameObject);
                }
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


    private void CreateUI()
    {
        heartList = new GameObject[maxHealth / 2];
        
        for(int i = healthbar.transform.childCount; i > 0; i--)
        {
            Destroy(healthbar.transform.GetChild(i - 1).gameObject);
        }

        for(int i = 0; i < maxHealth/2; i++)
        {
            GameObject temp = Instantiate(heartPrefab, new Vector2(0, 0), Quaternion.identity, healthbar.transform);
            temp.GetComponent<RectTransform>().anchoredPosition = new Vector2(30 + i * 48, -22.5f);

            heartList[i] = temp;
        }

        UpdateUI();
    }


    private void UpdateUI()
    {
        if(isPlayer)
        {
            for(int i = 0; i < maxHealth / 2; i++)
            {
                int hp = curHealth - i * 2;

                if(hp != 1)
                {
                    hp = hp < 1 ? 0 : 2;
                }

                heartList[i].GetComponent<Image>().sprite = heartSprite[hp];
            }
        }

        if(!isPlayer)
        {
            float perc = (float)curHealth / maxHealth;

            GameObject redbar = healthbar.transform.GetChild(0).gameObject;
            print(perc);
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
