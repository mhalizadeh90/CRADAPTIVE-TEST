using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetPositionOnDrop : MonoBehaviour,IPointerUpHandler
{
    RectTransform rectTransform;
    Vector3 defaultPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultPosition = rectTransform.anchoredPosition3D;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetToDefaultPosition();
        OnItemReset?.Invoke();
    }

    public void ResetToDefaultPosition()
    {
        rectTransform.anchoredPosition3D = defaultPosition;
    }


    public static Action OnItemReset;
}
