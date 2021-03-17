using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlaceholderType : MonoBehaviour
{

    [SerializeField] LoadoutType placeholderType;
    LoadoutItem LoadoutItem;

    void Awake()
    {
        LoadoutItem = GetComponent<LoadoutItem>();
    }

    void OnEnable()
    {
        DropEventTrigger.OnDroppedOnLoadout += CheckDroppedLoadout;
    }
    void CheckDroppedLoadout(Loadout droppedLoadout)
    {
        if (droppedLoadout.Type != placeholderType)
            return;

        LoadoutItem.UpdateLoadout(droppedLoadout);
    }

    void OnDisable()
    {
        DropEventTrigger.OnDroppedOnLoadout -= CheckDroppedLoadout;
    }

}
