using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowCursorOnDrag : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    RectTransform rectTransform;
    float canvasScale = 1;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        broadcastCanvasScale.onMainCanvasEnabled += GetCanvasScale;
    }

    void GetCanvasScale(float canvasScale)
    {
        this.canvasScale = canvasScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDragStart?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvasScale;
    }

    void OnDisable()
    {
        broadcastCanvasScale.onMainCanvasEnabled -= GetCanvasScale;
    }

    public static Action OnDragStart;

}
