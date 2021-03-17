using UnityEngine;
using UnityEngine.UI;

public class LoadoutItem : MonoBehaviour, IItem
{
    Item loadout;
    Image imageRenderer;

    void Awake()
    {
        imageRenderer = GetComponent<Image>();
        UpdateItem(loadout);
    }

    public void UpdateItem(Item newLoadout = null)
    {
        loadout = newLoadout;

        if (loadout == null)
            imageRenderer.enabled = false;
        else
        {
            imageRenderer.sprite = loadout.Image;
            imageRenderer.enabled = true;
        }
    }

    public bool IsItemNull()
    {
        return (loadout == null);
    }

    public Item GetItem()
    {
        return loadout;
    }
}
