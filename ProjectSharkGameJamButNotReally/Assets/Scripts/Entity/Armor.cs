using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

public class Armor : MonoBehaviour
{

    [Header("Armor Stats")]
    public int helmetHP;
    public int chestHP;
    public int legHP;
    [Space]
    public int helmetSpeed;
    public int chestSpeed;
    public int legSpeed;
    [Space]
    public int totalHP;
    public int totalSpeed;


    [Header("GameObjects")]
    private GameObject manager;


    void Start()
    {
        manager = GameObject.Find("Manager");

        //UpdateArmor();
    }


    public void UpdateArmor()
    {
        if (manager.GetComponent<Inventory>().armor[0] != null)
        {
            helmetHP = manager.GetComponent<Inventory>().armor[0].valueOne;
            helmetSpeed = manager.GetComponent<Inventory>().armor[0].valueTwo;
        } else {
            helmetHP = 0;
            helmetSpeed = 0;
        }

        if (manager.GetComponent<Inventory>().armor[1] != null)
        {
            chestHP = manager.GetComponent<Inventory>().armor[1].valueOne;
            chestSpeed = manager.GetComponent<Inventory>().armor[1].valueTwo;
        } else {
            chestHP = 0;
            chestSpeed = 0;
        }

        if (manager.GetComponent<Inventory>().armor[2] != null)
        {
            legHP = manager.GetComponent<Inventory>().armor[2].valueOne;
            legSpeed = manager.GetComponent<Inventory>().armor[2].valueTwo;
        } else {
            legHP = 0;
            legSpeed = 0;
        }

        totalHP = helmetHP + chestHP + legHP;
        totalSpeed = helmetSpeed + chestSpeed + legSpeed;

        GetComponent<Player>().actualVel = GetComponent<Player>().Velocity * (1 + totalSpeed / 100f);
        print(GetComponent<Player>().actualVel);
        GetComponent<Health>().UpdateArmor(totalHP);
    }

    public void UpdateWeapon()
    {
        int dmg;

        if(manager.GetComponent<Inventory>().extra[0] != null)
        {
            dmg = manager.GetComponent<Inventory>().extra[0].valueOne;
        } else {
            dmg = 1;
        }

        transform.GetChild(0).gameObject.GetComponent<Attack>().damage = dmg;
    }
}
