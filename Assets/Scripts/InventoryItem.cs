using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(CanvasGroup))]
public class InventoryItem : MonoBehaviour
{

    public Loadout loadout;
    Image imageRenderer;
    CanvasGroup canvasGroup;

    void Awake()
    {
        imageRenderer = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
        UpdateLoadout(loadout);
    }


    void Start()
    {
        OnInventoryItemEnabled?.Invoke(this);
    }

    public void UpdateLoadout(Loadout newLoadout = null)
    {
        loadout = newLoadout;

        if (loadout == null)
            canvasGroup.alpha = 0;
        else
        {
            imageRenderer.sprite = loadout.Image;
            canvasGroup.alpha = 1;
        }
    }

    public static Action<InventoryItem> OnInventoryItemEnabled;

}
