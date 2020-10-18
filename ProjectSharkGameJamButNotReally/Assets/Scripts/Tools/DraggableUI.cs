using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [Header("Setup")]
    private Canvas canvas;
    private CanvasGroup cGroup;
    private RectTransform rect;

    public Vector3 prevPos;
    public bool verifiedSlot;

    public GameObject parentSlot;
    public int index;
    private GameObject manager;

    public string currentItemType;

    private void Awake()
    {
        manager = GameObject.Find("Manager");
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rect = GetComponent<RectTransform>();
        cGroup = GetComponent<CanvasGroup>();

        prevPos = rect.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        manager.GetComponent<Inventory>().DisableRaycastExcept(this);
        cGroup.alpha = .75f;
        verifiedSlot = false;
        cGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cGroup.alpha = 1;
        cGroup.blocksRaycasts = true;

        if(!verifiedSlot)
        {
            rect.anchoredPosition = prevPos;
        } else {
            prevPos = rect.anchoredPosition;
        }

        manager.GetComponent<Inventory>().EnableRaycast();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

}
