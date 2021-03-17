using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AudioFile")]
public class AudioClips : ScriptableObject
{
    public AudioClip ClickSFX;
    public AudioClip DragSFX;
    public AudioClip DropSFX;
    public AudioClip RemoveSFX;

}
