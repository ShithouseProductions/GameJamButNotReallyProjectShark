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
    public Item[] inv = new Item[18];
    public Item[] armor = new Item[3];
    public Item[] extra = new Item[3];



    [Header("GameObjects")]
    private GameObject invParent;
    private GameObject[] invGO = new GameObject[18];
    private GameObject[] armorGO = new GameObject[3];
    private GameObject[] extraGO = new GameObject[3];

    public GameObject[] allDraggable = new GameObject[24];

    private GameObject player;

    void Start()
    {
        invParent = GameObject.Find("_Inventory");
        player = GameObject.Find("Player");

        for(int i = 0; i < 24; i++)
        {
            allDraggable[i] = invParent.transform.GetChild(0).transform.GetChild(i + 26).gameObject;
            allDraggable[i].GetComponent<DraggableUI>().parentSlot = invParent.transform.GetChild(0).transform.GetChild(i + 2).gameObject;

            if(i < 18)
            {
                allDraggable[i].GetComponent<DraggableUI>().index = i;
            } else if(i < 21)
            {
                allDraggable[i].GetComponent<DraggableUI>().index = i - 18;
            } else {
                allDraggable[i].GetComponent<DraggableUI>().index = i - 21;
            }
            
        }

        for (int i = 0; i < 18; i++)
        {
            invGO[i] = invParent.transform.GetChild(0).transform.GetChild(i + 2).gameObject;
            invGO[i].GetComponent<InventorySlut>().currentItem = allDraggable[i];
            invGO[i].GetComponent<InventorySlut>().type = "INV";
        }
        for (int i = 0; i < 3; i++)
        {
            armorGO[i] = invParent.transform.GetChild(0).transform.GetChild(i + 20).gameObject;
            armorGO[i].GetComponent<InventorySlut>().currentItem = allDraggable[i + 18];
        }
        armorGO[0].GetComponent<InventorySlut>().type = "HELMET";
        armorGO[1].GetComponent<InventorySlut>().type = "CHEST";
        armorGO[2].GetComponent<InventorySlut>().type = "LEGS";

        for (int i = 0; i < 3; i++)
        {
            extraGO[i] = invParent.transform.GetChild(0).transform.GetChild(i + 23).gameObject;
            extraGO[i].GetComponent<InventorySlut>().currentItem = allDraggable[i + 21];
        }
        extraGO[0].GetComponent<InventorySlut>().type = "WEAPON";
        extraGO[1].GetComponent<InventorySlut>().type = "POTION";
        extraGO[2].GetComponent<InventorySlut>().type = "POTION";


        for (int i = 0; i < 18; i++)
        {
            //inv[i] = null;
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

    public void DisableRaycastExcept(DraggableUI dismiss)
    {
        for(int i = 0; i < 24; i++)
        {
            if (allDraggable[i] != dismiss)
            {
                allDraggable[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
    }

    public void EnableRaycast()
    {
        for (int i = 0; i < 24; i++)
        {

            allDraggable[i].GetComponent<CanvasGroup>().blocksRaycasts = true;

        }
    }


    public void Pickup(Item item)
    {

        for(int i = 0; i < 18; i++)
        {
            if(inv[i].itemName == null || inv[i].itemName == "")
            {
                inv[i] = item;
                invGO[i].GetComponent<InventorySlut>().currentItem.GetComponent<Image>().sprite = item.sprite;

                invGO[i].GetComponent<InventorySlut>().currentItem.GetComponent<DraggableUI>().currentItemType = item.type;

                if(item.type == "HELMET" || item.type == "CHEST" || item.type == "LEGS")
                {
                    //player.GetComponent<Armor>().upd
                }

                break;
            }
        }
    }

    public void MoveItem(string fromType, int fromIndex, string toType, int toIndex)
    {
        Item[] fromArray = new Item[0];
        Item[] toArray = new Item[0];

        bool affectedArmor = false;

        //print("fromType: " + fromType + ", fromIndex: " + fromIndex + ", toType: " + toType + ", toIne: " + toIndex);
        if(fromType == "INV")
        {
            fromArray = inv;
        }
        if(fromType == "HELMET" || fromType == "CHEST" || fromType == "LEGS")
        {
            fromArray = armor;
            affectedArmor = true;
        }
        if(fromType == "WEAPON" || fromType == "POTION")
        {
            fromArray = extra;
        }

        if(toType == "INV")
        {
            toArray = inv;
        }
        if (toType == "HELMET" || toType == "CHEST" || toType == "LEGS")
        {
            toArray = armor;
            affectedArmor = true;
        }
        if (toType == "WEAPON" || toType == "POTION")
        {
            toArray = extra;
        }

        Item temp = fromArray[fromIndex];
        fromArray[fromIndex] = toArray[toIndex];
        toArray[toIndex] = temp;


        if(affectedArmor)
        {
            player.GetComponent<Armor>().UpdateArmor();
        }
        
    }

}
