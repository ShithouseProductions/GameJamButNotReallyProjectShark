using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [Header("Tools")]
    [HideInInspector] public bool inventoryVisible = false;


    [Header("Inventory")]
    private Item[] inv = new Item[18];
    private Item[] armor = new Item[3];
    private Item[] extra = new Item[3];


    [Header("GameObjects")]
    private GameObject invGO;
    
    void Start()
    {
        invGO = GameObject.Find("_Inventory");
        invGO.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryVisible)
            {
                invGO.SetActive(false);
                GetComponent<GameController>().isPaused = false;
            } else {
                invGO.SetActive(true);
                GetComponent<GameController>().isPaused = true;
            }

            inventoryVisible = !inventoryVisible;
        }
    }
}
