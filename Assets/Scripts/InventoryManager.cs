using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    List<IItem> inventoryItems;

    void Awake()
    {
        inventoryItems = new List<IItem>();
    }

    void OnEnable()
    {
        InventoryItem.OnInventoryItemEnabled += InitializeInventoryItem;
        RemoveLoadoutFromCharacter.OnLoadoutRemove += FillEmptyInventorySlot;
    }

    void InitializeInventoryItem(IItem item)
    {
        inventoryItems.Add(item);
    }

    void FillEmptyInventorySlot(Item loadout)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if(inventoryItems[i].IsItemNull())
            {
                inventoryItems[i].UpdateItem(loadout);
                break;
            }
        }
    }

    void OnDisable()
    {
        InventoryItem.OnInventoryItemEnabled -= InitializeInventoryItem;
        RemoveLoadoutFromCharacter.OnLoadoutRemove -= FillEmptyInventorySlot;
    }


}
