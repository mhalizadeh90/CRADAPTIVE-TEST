using UnityEngine;

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
        DropItemHandler.OnDropLoadout += SetLoadoutBasedOnDroppedItem;
    }
    void SetLoadoutBasedOnDroppedItem(Item droppedLoadout)
    {
        if (droppedLoadout == null || droppedLoadout.Type != placeholderType)
            return;

        LoadoutItem.UpdateItem(droppedLoadout);
    }

    void OnDisable()
    {
        DropItemHandler.OnDropLoadout -= SetLoadoutBasedOnDroppedItem;
    }

}
