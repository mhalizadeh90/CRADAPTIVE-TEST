using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(CanvasGroup))]
public class InventoryItem : MonoBehaviour, IItem
{
    [SerializeField] Item item;

    Image imageRenderer;
    CanvasGroup canvasGroup;

    void Awake()
    {
        imageRenderer = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
        UpdateItem(item);
    }


    void Start()
    {
        OnInventoryItemEnabled?.Invoke(this);
    }

    public void UpdateItem(Item newLoadout = null)
    {
        item = newLoadout;

        if (item == null)
            canvasGroup.alpha = 0;
        else
        {
            imageRenderer.sprite = item.Image;
            canvasGroup.alpha = 1;
        }
    }

    public bool IsItemNull()
    {
        return (item == null);
    }

    public Item GetItem()
    {
        return item;
    }

    public static Action<IItem> OnInventoryItemEnabled;

}
