using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXPlayer;
    [SerializeField] AudioClips Clips;

    void OnEnable()
    {
        RemoveLoadoutFromCharacter.OnLoadoutRemove += PlayRemoveItemSFX;
        DropEventTrigger.OnDropped += PlayDropSFX;
        FollowCursorOnDrag.OnDragStart += PlayDragSFX;
        ResetPositionOnDrop.OnItemReset += PlayResetItemSFX;
    }

    public void PlayClickSFX()
    {
        SFXPlayer.clip = Clips.ClickSFX;
        SFXPlayer.Play();
    }

    public void PlayDragSFX()
    {
        SFXPlayer.clip = Clips.DragSFX;
        SFXPlayer.Play();
    }

    public void PlayDropSFX()
    {
        SFXPlayer.clip = Clips.DropSFX;
        SFXPlayer.Play();
    }

    public void PlayRemoveItemSFX(Loadout loadout)
    {
        //TODO: play different SFX for each Loadout type

        SFXPlayer.clip = Clips.RemoveSFX;
        SFXPlayer.Play();
    }

    public void PlayResetItemSFX()
    {
        SFXPlayer.clip = Clips.RemoveSFX;
        SFXPlayer.Play();
    }


    void OnDisable()
    {
        RemoveLoadoutFromCharacter.OnLoadoutRemove += PlayRemoveItemSFX;
        DropEventTrigger.OnDropped -= PlayDropSFX;
        FollowCursorOnDrag.OnDragStart -= PlayDragSFX;
        ResetPositionOnDrop.OnItemReset -= PlayResetItemSFX;
    }
}
