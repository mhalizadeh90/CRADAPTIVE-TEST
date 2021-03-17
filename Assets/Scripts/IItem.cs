using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    void UpdateItem(Item newLoadout = null);
    bool IsItemNull();
    Item GetItem();

}
