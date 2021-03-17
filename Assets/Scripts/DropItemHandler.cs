using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(IItem))]
public class DropItemHandler : MonoBehaviour, IDropHandler
{
    [SerializeField] DropType Type;
    IItem InventoryItem;

    void Awake()
    {
        InventoryItem = GetComponent<InventoryItem>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        IItem droppedItem = eventData.pointerDrag.GetComponent<IItem>();
    
        if (droppedItem == null)
            return;
       
        OnDropped?.Invoke();

        if (Type == DropType.InventorySlot)             ReplaceItemsInSlots(droppedItem);
        else if (Type == DropType.CharacterLoadout)     PutLoadoutOnCharacter(droppedItem);
    }

    void ReplaceItemsInSlots(IItem droppedInventoryItem)
    {
        Item tempDroppingLoadout = droppedInventoryItem.GetItem();

        droppedInventoryItem.UpdateItem(InventoryItem.GetItem());
        InventoryItem.UpdateItem(tempDroppingLoadout);
    }

    void PutLoadoutOnCharacter(IItem droppedInventoryItem)
    {
        OnDropLoadout?.Invoke(droppedInventoryItem.GetItem());
        droppedInventoryItem.UpdateItem();
    }

    public static Action<Item> OnDropLoadout;
    public static Action OnDropped;

}

public enum DropType
{
    InventorySlot, CharacterLoadout
}
