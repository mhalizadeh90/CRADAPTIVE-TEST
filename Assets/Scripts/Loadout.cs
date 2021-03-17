using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Loadout")]
public class Loadout : ScriptableObject
{
    public LoadoutType Type;
    public Sprite Image;
}

public enum LoadoutType
{
    Mask,Horn,Hair,Tail
}
