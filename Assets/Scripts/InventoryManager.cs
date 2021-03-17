using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    List<InventoryItem> inventoryItems;

    void Awake()
    {
        inventoryItems = new List<InventoryItem>();
    }

    void OnEnable()
    {
        InventoryItem.OnInventoryItemEnabled += InitializeInventoryItem;
        RemoveLoadoutFromCharacter.OnLoadoutRemove += FillEmptyInventorySlot;
    }

    void InitializeInventoryItem(InventoryItem item)
    {
        inventoryItems.Add(item);
    }

    void FillEmptyInventorySlot(Loadout loadout)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if(inventoryItems[i].loadout == null)
            {
                inventoryItems[i].UpdateLoadout(loadout);
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
