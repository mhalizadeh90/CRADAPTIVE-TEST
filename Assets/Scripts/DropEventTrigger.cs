using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropEventTrigger : MonoBehaviour, IDropHandler
{
    [SerializeField] DropType Type;
    InventoryItem InventoryItem;

    void Awake()
    {
        InventoryItem = GetComponent<InventoryItem>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
    
        if (!droppedItem)
            return;
       
        print("Item: " + droppedItem.name);
        OnDropped?.Invoke();

        if (Type == DropType.InventorySlot)
            ReplaceSlot(droppedItem);
        else if (Type == DropType.CharacterLoadout)
            PlaceOnCharacter(droppedItem);
    }

    void ReplaceSlot(InventoryItem droppedInventoryItem)
    {
        if (!droppedInventoryItem)
            return;

        Loadout tempDroppingLoadout = droppedInventoryItem.loadout;

        droppedInventoryItem.UpdateLoadout(InventoryItem.loadout);
        InventoryItem.UpdateLoadout(tempDroppingLoadout);
    }

    void PlaceOnCharacter(InventoryItem droppedInventoryItem)
    {
        OnDroppedOnLoadout?.Invoke(droppedInventoryItem.loadout);

        droppedInventoryItem.UpdateLoadout();

    }

    public static Action<Loadout> OnDroppedOnLoadout;
    public static Action OnDropped;

}

public enum DropType
{
    InventorySlot, CharacterLoadout
}
