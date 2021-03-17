using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class RemoveLoadoutFromCharacter : MonoBehaviour, IPointerClickHandler
{
    LoadoutItem loadoutItem;

    void Awake()
    {
        loadoutItem = GetComponent<LoadoutItem>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("OnPointerClick: "+transform.name);


        if (loadoutItem.loadout == null)
            return;

        OnLoadoutRemove?.Invoke(loadoutItem.loadout);
        loadoutItem.UpdateLoadout();
    }


    public static Action<Loadout> OnLoadoutRemove;
}
