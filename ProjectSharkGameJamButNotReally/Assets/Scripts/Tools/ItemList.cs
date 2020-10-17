using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{

    [Header("Equipment")]
    public Item[] helmetList;
    public Item[] chestList;
    public Item[] legList;
    [Space]
    public Item[] weaponList;
    public Item[] potionList;


    public Item GetItem(string type, int index)
    {
        Item item = null;

        switch(type)
        {
            case "HELMET":
                item = helmetList[index];
                break;
            case "CHEST":
                item = chestList[index];
                break;
            case "LEGS":
                item = legList[index];
                break;
            case "WEAPON":
                item = weaponList[index];
                break;
            case "POTION":
                item = potionList[index];
                break;
        }

        return item;
    }
}
