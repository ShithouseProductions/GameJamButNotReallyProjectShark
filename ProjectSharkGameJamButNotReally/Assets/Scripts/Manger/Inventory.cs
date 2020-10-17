using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [Header("Tools")]
    [HideInInspector] public bool inventoryVisisble = false;


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
            if(inventoryVisisble)
            {
                invGO.SetActive(false);
            } else {
                invGO.SetActive(true);            
            }

            inventoryVisisble = !inventoryVisisble;
        }
    }
}
