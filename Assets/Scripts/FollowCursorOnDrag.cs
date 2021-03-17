using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowCursorOnDrag : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    RectTransform rectTransform;
    [SerializeField] FloatVariable canvasScale;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvasScale.value;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDragStart?.Invoke();
    }

    public static Action OnDragStart;

}
