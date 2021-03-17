using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadoutItem : MonoBehaviour
{
    public Loadout loadout;
    Image imageRenderer;

    void Awake()
    {
        imageRenderer = GetComponent<Image>();
        UpdateLoadout(loadout);
    }

    public void UpdateLoadout(Loadout newLoadout = null)
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
}
