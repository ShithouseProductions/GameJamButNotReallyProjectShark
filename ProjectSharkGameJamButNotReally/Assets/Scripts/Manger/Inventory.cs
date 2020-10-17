using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [Header("Tools")]
    [HideInInspector] public bool inventoryVisible = false;


    [Header("Inventory")]
    private Item[] inv = new Item[18];
    private Item[] armor = new Item[3];
    private Item[] extra = new Item[3];



    [Header("GameObjects")]
    private GameObject invParent;
    private GameObject[] invGO = new GameObject[18];
    private GameObject[] armorGO = new GameObject[3];
    private GameObject[] extraGO = new GameObject[3];

    void Start()
    {
        invParent = GameObject.Find("_Inventory");

        for (int i = 0; i < 18; i++)
        {
            invGO[i] = invParent.transform.GetChild(0).transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < 3; i++)
        {
            armorGO[i] = invParent.transform.GetChild(1).transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < 3; i++)
        {
            extraGO[i] = invParent.transform.GetChild(2).transform.GetChild(i).gameObject;
        }

        invParent.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryVisible)
            {
                invParent.SetActive(false);
                GetComponent<GameController>().isPaused = false;
            } else {
                invParent.SetActive(true);
                GetComponent<GameController>().isPaused = true;
            }

            inventoryVisible = !inventoryVisible;
        }
    }


    public void Pickup(Item item)
    {

        for(int i = 0; i < 18; i++)
        {
            if(inv[i] == null)
            {
                inv[i] = item;

                invGO[i].transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;

                break;
            }
        }
    }


    public void Equip(string type, int index)
    {

    }



}
