using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [Header("Tools")]
    [HideInInspector] public bool inventoryVisible = false;


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
