using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class RemoveLoadoutFromCharacter : MonoBehaviour, IPointerClickHandler
{
    IItem loadoutItem;

    void Awake()
    {
        loadoutItem = GetComponent<IItem>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (loadoutItem == null || loadoutItem.IsItemNull())
            return;

        OnLoadoutRemove?.Invoke(loadoutItem.GetItem());
        loadoutItem.UpdateItem();
    }


    public static Action<Item> OnLoadoutRemove;
}
