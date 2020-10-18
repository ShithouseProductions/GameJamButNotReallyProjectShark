using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlut : MonoBehaviour, IDropHandler
{

    public string type;
    public GameObject currentItem;
    private GameObject manager;

    void Start()
    {
        manager = GameObject.Find("Manager");
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            string thisSlotType = type;
            string newSlotType = eventData.pointerDrag.GetComponent<DraggableUI>().parentSlot.GetComponent<InventorySlut>().type;
            string thisItemType = currentItem.GetComponent<DraggableUI>().currentItemType;
            string newItemType = eventData.pointerDrag.GetComponent<DraggableUI>().currentItemType;

            //Compare new item with this slot
            if(newItemType != "")
            {
                if (thisSlotType == "HELMET" && newItemType != "HELMET")
                    return;

                if (thisSlotType == "CHEST" && newItemType != "CHEST")
                    return;

                if (thisSlotType == "LEGS" && newItemType != "LEGS")
                    return;

                if (thisSlotType == "WEAPON" && newItemType != "WEAPON")
                    return;

                if (thisSlotType == "POTION" && newItemType != "POTION")
                    return;
            }


            //Compare this item with other slot
            if(thisItemType != "")
            {
                if (newSlotType == "HELMET" && thisItemType != "HELMET")
                    return;

                if (newSlotType == "HELMET" && thisItemType != "HELMET")
                    return;

                if (newSlotType == "LEGS" && thisItemType != "LEGS")
                    return;

                if (newSlotType == "WEAPON" && thisItemType != "WEAPON")
                    return;

                if (newSlotType == "POTION" && thisItemType != "POTION")
                    return;
            }





            //if statements to see if valid

            GameObject temp = currentItem;

            //Save currentItem
            currentItem = eventData.pointerDrag.gameObject;
            currentItem.GetComponent<DraggableUI>().parentSlot.GetComponent<InventorySlut>().currentItem = temp;

            //Set parents
            temp.GetComponent<DraggableUI>().parentSlot = currentItem.GetComponent<DraggableUI>().parentSlot;
            currentItem.GetComponent<DraggableUI>().parentSlot = this.gameObject;

            //Set index
            int tempIndex = temp.GetComponent<DraggableUI>().index;
            temp.GetComponent<DraggableUI>().index = currentItem.GetComponent<DraggableUI>().index;
            currentItem.GetComponent<DraggableUI>().index = tempIndex;

            //Move old item to draggeds previous position
            temp.GetComponent<RectTransform>().anchoredPosition = temp.GetComponent<DraggableUI>().parentSlot.GetComponent<RectTransform>().anchoredPosition;


            string fromType = temp.GetComponent<DraggableUI>().parentSlot.GetComponent<InventorySlut>().type;
            string toType = type;
            int fromIndex = temp.GetComponent<DraggableUI>().index;
            int toIndex = currentItem.GetComponent<DraggableUI>().index;

            manager.GetComponent<Inventory>().MoveItem(fromType, fromIndex, toType, toIndex);

            eventData.pointerDrag.GetComponent<DraggableUI>().verifiedSlot = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
